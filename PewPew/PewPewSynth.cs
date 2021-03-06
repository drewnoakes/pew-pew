using System;
using NAudio.Wave;

// ReSharper disable IdentifierTypo
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace PewPew
{
    public sealed class PewPewSynth : ISampleProvider
    {
        private enum EnvStage
        {
            Attack = 0,
            Sustain = 1,
            Decay = 2
        }

        private readonly Random _random = new Random();

        private const float master_vol = 0.05f;
        private const float sound_vol = 0.5f;

        private PewPewPatch _patch;

        private const int PhaserBufferLength = 1024;
        private const int NoiseBufferLength = 32;

        private bool _isPlaying;

        private int _phase;
        private double fperiod;
        private double fmaxperiod;
        private double fslide;
        private double fdslide;
        private int period;
        private float square_duty;
        private float square_slide;
        private EnvStage env_stage;
        private int env_time;
        private readonly int[] env_length = new int[3];
        private float env_vol;
        private float fphase;
        private float fdphase;
        private int iphase;
        private readonly float[] phaser_buffer = new float[PhaserBufferLength];
        private int ipp;
        private readonly float[] noise_buffer = new float[NoiseBufferLength];
        private float fltp;
        private float fltdp;
        private float fltw;
        private float fltw_d;
        private float fltdmp;
        private float fltphp;
        private float flthp;
        private float flthp_d;
        private float vib_phase;
        private float vib_speed;
        private float vib_amp;
        private int rep_time;
        private int rep_limit;
        private int arp_time;
        private int arp_limit;
        private double arp_mod;

        public void Play(PewPewPatch patch)
        {
            _patch = patch;
            Initialise(restart: false);
            _isPlaying = true;
        }

        private void Initialise(bool restart)
        {
            fperiod = 100.0/(_patch.StartFrequency*_patch.StartFrequency + 0.001);
            period = (int)fperiod;
            fmaxperiod = 100.0/(_patch.MinimumFrequency*_patch.MinimumFrequency + 0.001);
            fslide = 1.0 - Math.Pow(_patch.FrequencySlide, 3.0)*0.01;
            fdslide = -Math.Pow(_patch.FrequencyDeltaSlide, 3.0)*0.000001;
            square_duty = 0.5f - _patch.SquareWaveDuty*0.5f;
            square_slide = -_patch.SquareWaveDutySweep*0.00005f;
            if (_patch.ArpMod >= 0f)
                arp_mod = 1.0 - Math.Pow(_patch.ArpMod, 2.0)*0.9;
            else
                arp_mod = 1.0 + Math.Pow(_patch.ArpMod, 2.0)*10.0;
            arp_time = 0;
            arp_limit = (int)(Math.Pow(1f - _patch.ArpSpeed, 2f)*20000 + 32);
            if (_patch.ArpSpeed == 1f)
                arp_limit = 0;

            if (!restart)
            {
                _phase = 0;
                // reset filter
                fltp = 0f;
                fltdp = 0f;
                fltw = (float)Math.Pow(_patch.LpfCutoffFrequency, 3f)*0.1f;
                fltw_d = 1f + _patch.LpfCutoffSweep*0.0001f;
                fltdmp = 5f/(1f + (float)Math.Pow(_patch.LpfResonance, 2f)*20f)*(0.01f + fltw);
                if (fltdmp > 0.8f)
                    fltdmp = 0.8f;
                fltphp = 0f;
                flthp = (float)Math.Pow(_patch.HpfCutoffFrequency, 2f)*0.1f;
                flthp_d = 1f + _patch.HpfSweep*0.0003f;
                // reset vibrato
                vib_phase = 0f;
                vib_speed = (float)Math.Pow(_patch.VibratoSpeed, 2f)*0.01f;
                vib_amp = _patch.VibratoDepth*0.5f;
                // reset envelope
                env_vol = 0f;
                env_stage = EnvStage.Attack;
                env_time = 0;
                env_length[(int)EnvStage.Attack]  = (int)(_patch.EnvelopeAttackTime*_patch.EnvelopeAttackTime*100000f);
                env_length[(int)EnvStage.Sustain] = (int)(_patch.EnvelopeSustainTime*_patch.EnvelopeSustainTime*100000f);
                env_length[(int)EnvStage.Decay]   = (int)(_patch.EnvelopeDecayTime*_patch.EnvelopeDecayTime*100000f);

                fphase = (float)Math.Pow(_patch.PhaserOffset, 2f)*1020f;
                if (_patch.PhaserOffset < 0f)
                    fphase = -fphase;
                fdphase = (float)Math.Pow(_patch.PhaserSweep, 2f)*1f;
                if (_patch.PhaserSweep < 0f)
                    fdphase = -fdphase;
                iphase = Math.Abs((int)fphase);
                ipp = 0;
                Array.Clear(phaser_buffer, 0, PhaserBufferLength);

                for (var i = 0; i < NoiseBufferLength; i++)
                    noise_buffer[i] = (float)_random.NextDouble()*2f - 1f;

                rep_time = 0;
                rep_limit = (int)(Math.Pow(1f - _patch.RepeatSpeed, 2f)*20000 + 32);
                if (_patch.RepeatSpeed == 0f)
                    rep_limit = 0;
            }
        }

        int ISampleProvider.Read(float[] buffer, int offset, int sampleCount)
        {
            for (var i = 0; i < sampleCount; i++)
            {
                if (!_isPlaying)
                    return 0;

                rep_time++;
                if (rep_limit != 0 && rep_time >= rep_limit)
                {
                    rep_time = 0;
                    Initialise(restart: true);
                }

                // frequency envelopes/arpeggios
                arp_time++;
                if (arp_limit != 0 && arp_time >= arp_limit)
                {
                    arp_limit = 0;
                    fperiod *= arp_mod;
                }
                fslide += fdslide;
                fperiod *= fslide;
                if (fperiod > fmaxperiod)
                {
                    fperiod = fmaxperiod;
                    if (_patch.MinimumFrequency > 0f)
                        _isPlaying = false;
                }
                var rfperiod = (float)fperiod;
                if (vib_amp > 0f)
                {
                    vib_phase += vib_speed;
                    rfperiod = (float)(fperiod*(1.0 + Math.Sin(vib_phase)*vib_amp));
                }
                period = (int)rfperiod;
                if (period < 8)
                    period = 8;

                square_duty += square_slide;
                if (square_duty < 0f)
                    square_duty = 0f;
                else if (square_duty > 0.5f)
                    square_duty = 0.5f;

                // volume envelope
                env_time++;
                if (env_time > env_length[(int)env_stage])
                {
                    env_time = 0;
                    if (env_stage == EnvStage.Decay)
                        _isPlaying = false;
                    else
                        env_stage++;
                }

                switch (env_stage)
                {
                    case EnvStage.Attack:
                        env_vol = (float)env_time/env_length[(int)EnvStage.Attack];
                        break;
                    case EnvStage.Sustain:
                        env_vol = 1f + (float)Math.Pow(1f - (float)env_time/env_length[(int)EnvStage.Sustain], 1f)*2f*_patch.EnvelopeSustainPunch;
                        break;
                    case EnvStage.Decay:
                        env_vol = 1f - (float)env_time/env_length[(int)EnvStage.Decay];
                        break;
                }

                // phaser step
                fphase += fdphase;
                iphase = Math.Abs((int)fphase);
                if (iphase > 1023)
                    iphase = 1023;

                if (flthp_d != 0)
                {
                    flthp *= flthp_d;
                    if (flthp < 0.00001f)
                        flthp = 0.00001f;
                    if (flthp > 0.1f)
                        flthp = 0.1f;
                }

                // 8x supersampling
                var ssample = 0f;
                for (var si = 0; si < 8; si++)
                {
                    var sample = 0f;
                    _phase++;
                    if (_phase >= period)
                    {
//				        phase = 0;
                        _phase %= period;
                        if (_patch.WaveType == PewPewWaveType.Noise)
                        {
                            for (var j = 0; j < NoiseBufferLength; j++)
                                noise_buffer[j] = (float)_random.NextDouble()*2f - 1f;
                        }
                    }

                    // base waveform
                    var fp = (float)_phase/period;
                    switch (_patch.WaveType)
                    {
                        case PewPewWaveType.Square:
                            sample = fp < square_duty ? 0.5f : -0.5f;
                            break;
                        case PewPewWaveType.Sawtooth:
                            sample = 1f - fp*2;
                            break;
                        case PewPewWaveType.Sine:
                            sample = (float)Math.Sin(fp*2*Math.PI);
                            break;
                        case PewPewWaveType.Noise:
                            sample = noise_buffer[_phase* NoiseBufferLength / period];
                            break;
                    }

                    // lp filter
                    var pp = fltp;
                    fltw *= fltw_d;
                    if (fltw < 0f)
                        fltw = 0f;
                    if (fltw > 0.1f)
                        fltw = 0.1f;
                    if (_patch.LpfCutoffFrequency != 1f)
                    {
                        fltdp += (sample - fltp)*fltw;
                        fltdp -= fltdp*fltdmp;
                    }
                    else
                    {
                        fltp = sample;
                        fltdp = 0f;
                    }
                    fltp += fltdp;
                    // hp filter
                    fltphp += fltp - pp;
                    fltphp -= fltphp*flthp;
                    sample = fltphp;
                    // phaser
                    phaser_buffer[ipp & 1023] = sample;
                    sample += phaser_buffer[(ipp - iphase + PhaserBufferLength) & 1023];
                    ipp = (ipp + 1) & 1023;
                    // final accumulation and envelope application
                    ssample += sample*env_vol;
                }
                ssample = ssample/8*master_vol;

                ssample *= 2f*sound_vol;

                if (ssample > 1f)
                    ssample = 1f;
                if (ssample < -1f)
                    ssample = -1f;

                buffer[offset++] = ssample;
            }

            return sampleCount;
        }

        WaveFormat ISampleProvider.WaveFormat => PewPewMixer.WaveFormat;
    }
}
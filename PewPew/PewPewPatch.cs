// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global

namespace PewPew
{
    public enum PewPewWaveType
    {
        Square,
        Sawtooth,
        Sine,
        Noise
    }

    public sealed class PewPewPatch
    {
        public PewPewWaveType WaveType { get; set; }

        public float StartFrequency { get; set; }
        public float MinimumFrequency { get; set; }
        public float FrequencySlide { get; set; }
        public float FrequencyDeltaSlide { get; set; }

        public float SquareWaveDuty { get; set; }
        public float SquareWaveDutySweep { get; set; }

        /// <summary>Strength of the vibrato effect.</summary>
        public float VibratoDepth { get; set; }
        /// <summary>Rate of the vibrato effect.</summary>
        public float VibratoSpeed { get; set; }

        public float EnvelopeAttackTime { get; set; }
        public float EnvelopeSustainTime { get; set; }
        public float EnvelopeDecayTime { get; set; }
        public float EnvelopeSustainPunch { get; set; }

        public float LpfResonance { get; set; }
        public float LpfCutoffFrequency { get; set; }
        public float LpfCutoffSweep { get; set; }

        public float HpfCutoffFrequency { get; set; }
        public float HpfSweep { get; set; }

        public float PhaserOffset { get; set; }
        public float PhaserSweep { get; set; }

        public float RepeatSpeed { get; set; }

        public float ArpSpeed { get; set; }
        public float ArpMod { get; set; }

        public PewPewPatch(
            PewPewWaveType waveType = PewPewWaveType.Square,
            float startFrequency = 0.3f,
            float minimumFrequency = 0.1f,
            float frequencySlide = 0,
            float frequencyDeltaSlide = 0,
            float squareWaveDuty = 0,
            float squareWaveDutySweep = 0,
            float vibratoDepth = 0,
            float vibratoSpeed = 0,
            float envelopeAttackTime = 0,
            float envelopeSustainTime = 0.3f,
            float envelopeDecayTime = 0.4f,
            float envelopeSustainPunch = 0,
            float lpfResonance = 0,
            float lpfCutoffFrequency = 1,
            float lpfCutoffSweep = 0,
            float hpfCutoffFrequency = 0,
            float hpfSweep = 0,
            float phaserOffset = 0,
            float phaserSweep = 0,
            float repeatSpeed = 0,
            float arpSpeed = 0,
            float arpMod = 0)
        {
            WaveType = waveType;
            StartFrequency = startFrequency;
            MinimumFrequency = minimumFrequency;
            FrequencySlide = frequencySlide;
            FrequencyDeltaSlide = frequencyDeltaSlide;
            SquareWaveDuty = squareWaveDuty;
            SquareWaveDutySweep = squareWaveDutySweep;
            VibratoDepth = vibratoDepth;
            VibratoSpeed = vibratoSpeed;
            EnvelopeAttackTime = envelopeAttackTime;
            EnvelopeSustainTime = envelopeSustainTime;
            EnvelopeDecayTime = envelopeDecayTime;
            EnvelopeSustainPunch = envelopeSustainPunch;
            LpfResonance = lpfResonance;
            LpfCutoffFrequency = lpfCutoffFrequency;
            LpfCutoffSweep = lpfCutoffSweep;
            HpfCutoffFrequency = hpfCutoffFrequency;
            HpfSweep = hpfSweep;
            PhaserOffset = phaserOffset;
            PhaserSweep = phaserSweep;
            RepeatSpeed = repeatSpeed;
            ArpSpeed = arpSpeed;
            ArpMod = arpMod;
        }
    }
}
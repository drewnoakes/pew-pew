// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Sfxr
{
    public enum SfxrWaveType
    {
        Square,
        Sawtooth,
        Sine,
        Noise
    }

    public sealed class SfxrPatch
    {
        public SfxrWaveType WaveType { get; set; }

        public float BaseFreq { get; set; }
        public float FreqLimit { get; set; }
        public float FreqRamp { get; set; }
        public float FreqDramp { get; set; }
        public float Duty { get; set; }
        public float DutyRamp { get; set; }

        public float VibStrength { get; set; }
        public float VibSpeed { get; set; }

        public float EnvAttack { get; set; }
        public float EnvSustain { get; set; }
        public float EnvDecay { get; set; }
        public float EnvPunch { get; set; }

        public float LpfResonance { get; set; }
        public float LpfFreq { get; set; }
        public float LpfRamp { get; set; }
        public float HpfFreq { get; set; }
        public float HpfRamp { get; set; }

        public float PhaOffset { get; set; }
        public float PhaRamp { get; set; }

        public float RepeatSpeed { get; set; }

        public float ArpSpeed { get; set; }
        public float ArpMod { get; set; }

        public SfxrPatch(
            SfxrWaveType waveType = SfxrWaveType.Square,
            float baseFreq = 0.3f,
            float freqLimit = 0.1f,
            float freqRamp = 0,
            float freqDramp = 0,
            float duty = 0,
            float dutyRamp = 0,
            float vibStrength = 0,
            float vibSpeed = 0,
            float envAttack = 0,
            float envSustain = 0.3f,
            float envDecay = 0.4f,
            float envPunch = 0,
            float lpfResonance = 0,
            float lpfFreq = 1,
            float lpfRamp = 0,
            float hpfFreq = 0,
            float hpfRamp = 0,
            float phaOffset = 0,
            float phaRamp = 0,
            float repeatSpeed = 0,
            float arpSpeed = 0,
            float arpMod = 0)
        {
            WaveType = waveType;
            BaseFreq = baseFreq;
            FreqLimit = freqLimit;
            FreqRamp = freqRamp;
            FreqDramp = freqDramp;
            Duty = duty;
            DutyRamp = dutyRamp;
            VibStrength = vibStrength;
            VibSpeed = vibSpeed;
            EnvAttack = envAttack;
            EnvSustain = envSustain;
            EnvDecay = envDecay;
            EnvPunch = envPunch;
            LpfResonance = lpfResonance;
            LpfFreq = lpfFreq;
            LpfRamp = lpfRamp;
            HpfFreq = hpfFreq;
            HpfRamp = hpfRamp;
            PhaOffset = phaOffset;
            PhaRamp = phaRamp;
            RepeatSpeed = repeatSpeed;
            ArpSpeed = arpSpeed;
            ArpMod = arpMod;
        }
    }
}
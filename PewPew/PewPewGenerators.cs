using System;

namespace PewPew
{
    public static class PewPewGenerators
    {
        private static readonly Random _random = new Random();

        private static float RandF(float max) => (float)_random.NextDouble()*max;
        private static bool Chance(double probability) => _random.NextDouble() <= probability;

        public static PewPewPatch Pickup()
        {
            var patch = new PewPewPatch(
                startFrequency: 0.4f + RandF(0.5f),
                envelopeAttackTime: 0,
                envelopeSustainTime: RandF(0.1f),
                envelopeDecayTime: 0.1f + RandF(0.4f),
                envelopeSustainPunch: 0.3f + RandF(0.3f));

            if (Chance(0.5))
            {
                patch.ArpSpeed = 0.5f + RandF(0.2f);
                patch.ArpMod = 0.2f + RandF(0.4f);
            }

            return patch;
        }

        public static PewPewPatch Laser()
        {
            var patch = new PewPewPatch();

            patch.WaveType = (PewPewWaveType)_random.Next(0, 3);

            patch.EnvelopeAttackTime = 0.0f;
            patch.EnvelopeSustainTime = 0.1f + RandF(0.2f);
            patch.EnvelopeDecayTime = RandF(0.4f);
            if (Chance(0.5))
                patch.EnvelopeSustainPunch = RandF(0.3f);

            patch.StartFrequency = 0.5f + RandF(0.5f);
            patch.MinimumFrequency = (float)Math.Max(0.2, patch.StartFrequency - 0.2f - RandF(0.6f));

            if (Chance(1/3.0))
            {
                patch.StartFrequency = 0.3f + RandF(0.6f);
                patch.MinimumFrequency = RandF(0.1f);
                patch.FrequencySlide = -0.35f - RandF(0.3f);
            }

            if (patch.WaveType == PewPewWaveType.Square)
            {
                if (Chance(0.5))
                {
                    patch.SquareWaveDuty = RandF(0.5f);
                    patch.SquareWaveDutySweep = RandF(0.2f);
                }
                else
                {
                    patch.SquareWaveDuty = 0.4f + RandF(0.5f);
                    patch.SquareWaveDutySweep = -RandF(0.7f);
                }
            }

            if (Chance(1/3.0))
            {
                patch.PhaserOffset = RandF(0.2f);
                patch.PhaserSweep = -RandF(0.2f);
            }

            if (Chance(0.5))
                patch.HpfCutoffFrequency = RandF(0.3f);

            return patch;
        }

        public static PewPewPatch Explosion()
        {
            var patch = new PewPewPatch();

            patch.WaveType = PewPewWaveType.Noise;
            if (Chance(0.5))
            {
                patch.StartFrequency = 0.1f + RandF(0.4f);
                patch.FrequencySlide = -0.1f + RandF(0.4f);
            }
            else
            {
                patch.StartFrequency = 0.2f + RandF(0.7f);
                patch.FrequencySlide = -0.2f - RandF(0.2f);
            }
            patch.StartFrequency *= patch.StartFrequency;

            if (Chance(0.25))
                patch.FrequencySlide = 0.0f;
            if (Chance(1/3.0))
                patch.RepeatSpeed = 0.3f + RandF(0.5f);

            patch.EnvelopeAttackTime = 0.0f;
            patch.EnvelopeSustainTime = 0.1f + RandF(0.3f);
            patch.EnvelopeDecayTime = RandF(0.5f);

            if (Chance(0.5))
            {
                patch.PhaserOffset = -0.3f + RandF(0.9f);
                patch.PhaserSweep = -RandF(0.3f);
            }

            patch.EnvelopeSustainPunch = 0.2f + RandF(0.6f);

            if (Chance(0.5))
            {
                patch.VibratoDepth = RandF(0.7f);
                patch.VibratoSpeed = RandF(0.6f);
            }

            if (Chance(1/3.0))
            {
                patch.ArpSpeed = 0.6f + RandF(0.3f);
                patch.ArpMod = 0.8f - RandF(1.6f);
            }

            return patch;
        }

        public static PewPewPatch PowerUp()
        {
            var patch = new PewPewPatch();

            if (Chance(0.5))
            {
                patch.WaveType = PewPewWaveType.Sawtooth;
            }
            else
            {
                patch.WaveType = PewPewWaveType.Square;
                patch.SquareWaveDuty = RandF(0.6f);
            }

            if (Chance(0.5))
            {
                patch.StartFrequency = 0.2f + RandF(0.3f);
                patch.FrequencySlide = 0.1f + RandF(0.4f);
                patch.RepeatSpeed = 0.4f + RandF(0.4f);
            }
            else
            {
                patch.StartFrequency = 0.2f + RandF(0.3f);
                patch.FrequencySlide = 0.05f + RandF(0.2f);
                if (Chance(0.5))
                {
                    patch.VibratoDepth = RandF(0.7f);
                    patch.VibratoSpeed = RandF(0.6f);
                }
            }
            patch.EnvelopeAttackTime = 0.0f;
            patch.EnvelopeSustainTime = RandF(0.4f);
            patch.EnvelopeDecayTime = 0.1f + RandF(0.4f);

            return patch;
        }

        public static PewPewPatch Hurt()
        {
            var patch = new PewPewPatch();

            patch.WaveType = (PewPewWaveType)_random.Next(0, 3);
            if (patch.WaveType == PewPewWaveType.Sine)
                patch.WaveType = PewPewWaveType.Noise;
            if (patch.WaveType == PewPewWaveType.Square)
                patch.SquareWaveDuty = RandF(0.6f);
            patch.StartFrequency = 0.2f + RandF(0.6f);
            patch.FrequencySlide = -0.3f - RandF(0.4f);
            patch.EnvelopeAttackTime = 0.0f;
            patch.EnvelopeSustainTime = RandF(0.1f);
            patch.EnvelopeDecayTime = 0.1f + RandF(0.2f);
            if (Chance(0.5))
                patch.HpfCutoffFrequency = RandF(0.3f);

            return patch;
        }

        public static PewPewPatch Jump()
        {
            var patch = new PewPewPatch();

            patch.WaveType = 0;
            patch.SquareWaveDuty = RandF(0.6f);
            patch.StartFrequency = 0.3f + RandF(0.3f);
            patch.FrequencySlide = 0.1f + RandF(0.2f);
            patch.EnvelopeAttackTime = 0.0f;
            patch.EnvelopeSustainTime = 0.1f + RandF(0.3f);
            patch.EnvelopeDecayTime = 0.1f + RandF(0.2f);
            if (Chance(0.5))
                patch.HpfCutoffFrequency = RandF(0.3f);
            if (Chance(0.5))
                patch.LpfCutoffFrequency = 1.0f - RandF(0.6f);

            return patch;
        }

        public static PewPewPatch Blip()
        {
            var patch = new PewPewPatch();

            patch.WaveType = (PewPewWaveType)_random.Next(0, 2);
            if (patch.WaveType == 0)
                patch.SquareWaveDuty = RandF(0.6f);
            patch.StartFrequency = 0.2f + RandF(0.4f);
            patch.EnvelopeAttackTime = 0.0f;
            patch.EnvelopeSustainTime = 0.1f + RandF(0.1f);
            patch.EnvelopeDecayTime = RandF(0.2f);
            patch.HpfCutoffFrequency = 0.1f;

            return patch;
        }
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace PewPew.Editor
{
    public sealed class PatchViewModel : INotifyPropertyChanged
    {
        private PewPewWaveType _waveType = PewPewWaveType.Square;
        private float _startFrequency = 0.3f;
        private float _minimumFrequency = 0.1f;
        private float _frequencySlide;
        private float _frequencyDeltaSlide;
        private float _squareWaveDuty;
        private float _squareWaveDutySweep;
        private float _vibratoDepth;
        private float _vibratoSpeed;
        private float _envelopeAttackTime;
        private float _envelopeSustainTime = 0.3f;
        private float _envelopeDecayTime = 0.4f;
        private float _envelopeSustainPunch;
        private float _lpfResonance;
        private float _lpfCutoffFrequency = 1;
        private float _lpfCutoffSweep;
        private float _hpfCutoffFrequency;
        private float _hpfSweep;
        private float _phaserOffset;
        private float _phaserSweep;
        private float _repeatSpeed;
        private float _arpSpeed;
        private float _arpMod;

        public PewPewWaveType WaveType
        {
            get => _waveType;
            set
            {
                if (value == _waveType)
                    return;
                _waveType = value;
                OnPropertyChanged();
            }
        }

        public float StartFrequency
        {
            get => _startFrequency;
            set
            {
                if (value.Equals(_startFrequency))
                    return;
                _startFrequency = value;
                OnPropertyChanged();
            }
        }

        public float MinimumFrequency
        {
            get => _minimumFrequency;
            set
            {
                if (value.Equals(_minimumFrequency))
                    return;
                _minimumFrequency = value;
                OnPropertyChanged();
            }
        }

        public float FrequencySlide
        {
            get => _frequencySlide;
            set
            {
                if (value.Equals(_frequencySlide))
                    return;
                _frequencySlide = value;
                OnPropertyChanged();
            }
        }

        public float FrequencyDeltaSlide
        {
            get => _frequencyDeltaSlide;
            set
            {
                if (value.Equals(_frequencyDeltaSlide))
                    return;
                _frequencyDeltaSlide = value;
                OnPropertyChanged();
            }
        }

        public float SquareWaveDuty
        {
            get => _squareWaveDuty;
            set
            {
                if (value.Equals(_squareWaveDuty))
                    return;
                _squareWaveDuty = value;
                OnPropertyChanged();
            }
        }

        public float SquareWaveDutySweep
        {
            get => _squareWaveDutySweep;
            set
            {
                if (value.Equals(_squareWaveDutySweep))
                    return;
                _squareWaveDutySweep = value;
                OnPropertyChanged();
            }
        }

        public float VibratoDepth
        {
            get => _vibratoDepth;
            set
            {
                if (value.Equals(_vibratoDepth))
                    return;
                _vibratoDepth = value;
                OnPropertyChanged();
            }
        }

        public float VibratoSpeed
        {
            get => _vibratoSpeed;
            set
            {
                if (value.Equals(_vibratoSpeed))
                    return;
                _vibratoSpeed = value;
                OnPropertyChanged();
            }
        }

        public float EnvelopeAttackTime
        {
            get => _envelopeAttackTime;
            set
            {
                if (value.Equals(_envelopeAttackTime))
                    return;
                _envelopeAttackTime = value;
                OnPropertyChanged();
            }
        }

        public float EnvelopeSustainTime
        {
            get => _envelopeSustainTime;
            set
            {
                if (value.Equals(_envelopeSustainTime))
                    return;
                _envelopeSustainTime = value;
                OnPropertyChanged();
            }
        }

        public float EnvelopeDecayTime
        {
            get => _envelopeDecayTime;
            set
            {
                if (value.Equals(_envelopeDecayTime))
                    return;
                _envelopeDecayTime = value;
                OnPropertyChanged();
            }
        }

        public float EnvelopeSustainPunch
        {
            get => _envelopeSustainPunch;
            set
            {
                if (value.Equals(_envelopeSustainPunch))
                    return;
                _envelopeSustainPunch = value;
                OnPropertyChanged();
            }
        }

        public float LpfResonance
        {
            get => _lpfResonance;
            set
            {
                if (value.Equals(_lpfResonance))
                    return;
                _lpfResonance = value;
                OnPropertyChanged();
            }
        }

        public float LpfCutoffFrequency
        {
            get => _lpfCutoffFrequency;
            set
            {
                if (value.Equals(_lpfCutoffFrequency))
                    return;
                _lpfCutoffFrequency = value;
                OnPropertyChanged();
            }
        }

        public float LpfCutoffSweep
        {
            get => _lpfCutoffSweep;
            set
            {
                if (value.Equals(_lpfCutoffSweep))
                    return;
                _lpfCutoffSweep = value;
                OnPropertyChanged();
            }
        }

        public float HpfCutoffFrequency
        {
            get => _hpfCutoffFrequency;
            set
            {
                if (value.Equals(_hpfCutoffFrequency))
                    return;
                _hpfCutoffFrequency = value;
                OnPropertyChanged();
            }
        }

        public float HpfSweep
        {
            get => _hpfSweep;
            set
            {
                if (value.Equals(_hpfSweep))
                    return;
                _hpfSweep = value;
                OnPropertyChanged();
            }
        }

        public float PhaserOffset
        {
            get => _phaserOffset;
            set
            {
                if (value.Equals(_phaserOffset))
                    return;
                _phaserOffset = value;
                OnPropertyChanged();
            }
        }

        public float PhaserSweep
        {
            get => _phaserSweep;
            set
            {
                if (value.Equals(_phaserSweep))
                    return;
                _phaserSweep = value;
                OnPropertyChanged();
            }
        }

        public float RepeatSpeed
        {
            get => _repeatSpeed;
            set
            {
                if (value.Equals(_repeatSpeed))
                    return;
                _repeatSpeed = value;
                OnPropertyChanged();
            }
        }

        public float ArpSpeed
        {
            get => _arpSpeed;
            set
            {
                if (value.Equals(_arpSpeed))
                    return;
                _arpSpeed = value;
                OnPropertyChanged();
            }
        }

        public float ArpMod
        {
            get => _arpMod;
            set
            {
                if (value.Equals(_arpMod))
                    return;
                _arpMod = value;
                OnPropertyChanged();
            }
        }

        #region To/From Patch

        public PewPewPatch ToPatch()
        {
            return new PewPewPatch
            {
                WaveType = WaveType,
                StartFrequency = StartFrequency,
                MinimumFrequency = MinimumFrequency,
                FrequencySlide = FrequencySlide,
                FrequencyDeltaSlide = FrequencyDeltaSlide,
                SquareWaveDuty = SquareWaveDuty,
                SquareWaveDutySweep = SquareWaveDutySweep,
                VibratoDepth = VibratoDepth,
                VibratoSpeed = VibratoSpeed,
                EnvelopeAttackTime = EnvelopeAttackTime,
                EnvelopeSustainTime = EnvelopeSustainTime,
                EnvelopeDecayTime = EnvelopeDecayTime,
                EnvelopeSustainPunch = EnvelopeSustainPunch,
                LpfResonance = LpfResonance,
                LpfCutoffFrequency = LpfCutoffFrequency,
                LpfCutoffSweep = LpfCutoffSweep,
                HpfCutoffFrequency = HpfCutoffFrequency,
                HpfSweep = HpfSweep,
                PhaserOffset = PhaserOffset,
                PhaserSweep = PhaserSweep,
                RepeatSpeed = RepeatSpeed,
                ArpSpeed = ArpSpeed,
                ArpMod = ArpMod
            };
        }

        public void FromPatch(PewPewPatch patch)
        {
            WaveType = patch.WaveType;
            StartFrequency = patch.StartFrequency;
            MinimumFrequency = patch.MinimumFrequency;
            FrequencySlide = patch.FrequencySlide;
            FrequencyDeltaSlide = patch.FrequencyDeltaSlide;
            SquareWaveDuty = patch.SquareWaveDuty;
            SquareWaveDutySweep = patch.SquareWaveDutySweep;
            VibratoDepth = patch.VibratoDepth;
            VibratoSpeed = patch.VibratoSpeed;
            EnvelopeAttackTime = patch.EnvelopeAttackTime;
            EnvelopeSustainTime = patch.EnvelopeSustainTime;
            EnvelopeDecayTime = patch.EnvelopeDecayTime;
            EnvelopeSustainPunch = patch.EnvelopeSustainPunch;
            LpfResonance = patch.LpfResonance;
            LpfCutoffFrequency = patch.LpfCutoffFrequency;
            LpfCutoffSweep = patch.LpfCutoffSweep;
            HpfCutoffFrequency = patch.HpfCutoffFrequency;
            HpfSweep = patch.HpfSweep;
            PhaserOffset = patch.PhaserOffset;
            PhaserSweep = patch.PhaserSweep;
            RepeatSpeed = patch.RepeatSpeed;
            ArpSpeed = patch.ArpSpeed;
            ArpMod = patch.ArpMod;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
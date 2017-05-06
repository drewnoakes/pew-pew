using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace PewPew
{
    public sealed class PewPewMixer : IDisposable
    {
        private const int SampleRate = 44100;
        private const int ChannelCount = 1;

        internal static readonly WaveFormat WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(SampleRate, ChannelCount);

        private readonly Dictionary<ISampleProvider, TaskCompletionSource<byte>> _tcsByProvider = new Dictionary<ISampleProvider, TaskCompletionSource<byte>>();
        private readonly MixingSampleProvider _mixer = new MixingSampleProvider(WaveFormat) {ReadFully = true};
        private readonly ObjectPool<PewPewSynth> _synths = new ObjectPool<PewPewSynth>();
        private readonly WaveOut _waveOut = new WaveOut();

        public PewPewMixer()
        {
            // Configure mixer to stay playing,
            _mixer.ReadFully = true;
            _mixer.MixerInputEnded += (sender, args) =>
            {
                if (_tcsByProvider.TryGetValue(args.SampleProvider, out var tcs))
                {
                    _tcsByProvider.Remove(args.SampleProvider);
                    tcs.TrySetResult(0);
                }
                if (args.SampleProvider is PewPewSynth synth)
                    _synths.Release(synth);
            };

            _waveOut.Init(_mixer);
            _waveOut.Play();
        }

        public Task PlayAsync(PewPewPatch patch)
        {
            var synth = _synths.Take();

            synth.Play(patch);

            var tcs = new TaskCompletionSource<byte>(TaskCreationOptions.RunContinuationsAsynchronously);

            _tcsByProvider.Add(synth, tcs);

            _mixer.AddMixerInput(synth);

            return tcs.Task;
        }

        public void Dispose()
        {
            _waveOut.Stop();
            _waveOut.Dispose();
        }
    }
}
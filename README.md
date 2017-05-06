# pew-pew

This library is a port of the sfxr sound generator from C++ to C#.

It provides a simple way to synthesize and play sound effects.

Playback is provided by the amazing NAudio library.

## Usage

Minimal example is:

```csharp
using (var mixer = new PewPewMixer())
{
    await mixer.PlayAsync(new PewPewPatch());
}
```

You can play many sounds through the mixer before disposing it.
It supports polyphony (more than one sound can be playing a given moment in time).

To customise the sound, modify the `PewPewPatch` object before
calling `PlayAsync`.
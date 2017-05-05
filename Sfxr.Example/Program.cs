using System;
using System.Threading.Tasks;

namespace Sfxr.Example
{
    internal static class Program
    {
        private static int Main() => Task.Run(MainAsync).GetAwaiter().GetResult();

        private static async Task<int> MainAsync()
        {
            Console.Out.WriteLine($"Creating {nameof(SfxrMixer)}");

            using (var sfxr = new SfxrMixer())
            {
                Console.Out.WriteLine($"Playing {nameof(SfxrPatch)}");

                await sfxr.PlayAsync(new SfxrPatch());

                await Task.Delay(500);

                Console.Out.WriteLine("Playback complete");
            }

            return 0;
        }
    }
}

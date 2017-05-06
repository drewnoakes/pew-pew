using System;
using System.Threading.Tasks;

namespace PewPew.Example
{
    internal static class Program
    {
        private static int Main() => Task.Run(MainAsync).GetAwaiter().GetResult();

        private static async Task<int> MainAsync()
        {
            Console.Out.WriteLine($"Creating {nameof(PewPewMixer)}");

            using (var mixer = new PewPewMixer())
            {
                Console.Out.WriteLine($"Playing {nameof(PewPewPatch)}");

                await mixer.PlayAsync(new PewPewPatch());

                await Task.Delay(500);

                Console.Out.WriteLine("Playback complete");
            }

            return 0;
        }
    }
}

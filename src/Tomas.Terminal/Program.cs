// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
using System;

namespace Tomas.Terminal
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                var shell = new Shell();
                var command = shell.ReadLine;

                if (!TermConsts.Programs.TryGetValue(command, out var program))
                {
                    Console.WriteLine("Command Unknown.");
                    continue;
                }

                var start = program.Start();
                if (start) continue;

                break;
            }
        }
    }
}
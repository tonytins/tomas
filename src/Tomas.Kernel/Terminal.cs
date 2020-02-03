// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.
using System;
using Sys = Cosmos.System;

namespace Tomas.Kernel
{
    public class Terminal
    {
        const char SYMBOL = '$';

        static void Commands(string command)
        {
            switch (command)
            {
                case "fensay":
                    Console.WriteLine(EasterEggs.FenSay);
                    break;
                case "version":
                    Console.WriteLine(OSConsts.VersionGit);
                    break;
                case "reboot":
                    var rbq = ReadLine($"Are you sure you want to {command}? 1) Yes 2) No");
                    switch (rbq)
                    {
                        case "1":
                        case "yes":
                            Sys.Power.Reboot();
                            break;
                        case "2":
                        case "no":
                            break;
                    }
                    break;
                case "shutdown":
                    var shq = ReadLine($"Are you sure you want to {command}? 1) Yes 2) No");
                    switch (shq)
                    {
                        case "1":
                        case "yes":
                            Sys.Power.Shutdown();
                            break;
                        case "2":
                        case "no":
                            break;
                    }
                    break;
                case "ls":
                    var dirs = TomFS.ListDirectories(command.Remove(0, 2));
                    Console.WriteLine(dirs);
                    break;

            }
        }

        /// <summary>
        /// Same as Console.ReadLine() but adds a shell command symbol
        /// before the input.
        /// </summary>
        /// <returns>user's input</returns>
        public static string ReadLine()
        {

            Console.Write(SYMBOL);
            var readl = Console.ReadLine();
            Commands(readl);
            return readl;
        }

        /// <summary>
        /// Provides a message to the user above the shell command symbol.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>user's input</returns>
        public static string ReadLine(string message)
        {
            Console.WriteLine(message);
            Console.Write(SYMBOL);
            var readl = Console.ReadLine();
            Commands(readl);
            return readl;
        }
    }
}

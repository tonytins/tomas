// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.
using System;


namespace Tomas.Kernel
{
    public class Terminal
    {
        const char SYMBOL = '$';

        public static TerminalCancelEventHandler CancelKeyHandler;

        static void Commands(string command)
        {
            switch (command)
            {
                case "fensay":
                    Console.WriteLine(EasterEggs.FenSay);
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

using System;
using Tomas.Interface.Shell;

namespace Tomas.Terminal
{
    public class Shell : IShell
    {
        const char SYMBOL = '$';

        public string ReadLine
        {
            get
            {
                Console.Write(SYMBOL);
                var readl = Console.ReadLine();
                return readl;
            }
        }
    }
}
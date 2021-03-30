// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
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
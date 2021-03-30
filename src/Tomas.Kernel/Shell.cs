// TOMAS is licensed under the MPL 2.0 license.
// See the LICENSE file in the project root for more information.
using System;
using Tomas.Common;
using Tomas.Interface.Shell;
using Tomas.Kernel.Programs;
using Sys = Cosmos.System;

namespace Tomas.Kernel
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

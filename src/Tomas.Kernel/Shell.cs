// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using Tomas.Common.Programs;
using Tomas.Interface;
using Tomas.Kernel.Programs;
using Sys = Cosmos.System;

namespace Tomas.Kernel
{
    public class Shell : IShell
    {
        const char SYMBOL = '$';

        public Dictionary<string, IProgram> Programs => new Dictionary<string, IProgram>()
        {
            {"about", new About()},
            {"fensay", new FenSay()},
            {"clear", new Clear()},
            {"commands", new Commands()}
        };

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

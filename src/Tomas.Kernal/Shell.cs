// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;

namespace Tomas.Kernel;

public class Shell : IShell
{
    const char SYMBOL = '$';

    public Dictionary<string, IProgram> Programs => new()
    {
        {"about", new About() },
        {"fensay", new FenSay() },
        {"clear", new Clear() },
        {"commands", new Commands() }
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

// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
using System;
using Tomas.Common;

namespace Tomas.Kernel.Programs;

public class About : IProgram
{
    public bool Run(IShell shell)
    {
        Console.WriteLine($"{ComConsts.NAME} v{ComConsts.VersionGit}{Environment.NewLine}"
                        + "TOMAS (Tony's Managed Operating System) is a operating system written in C# using the COSMOS framework.");
        var progs = shell.Programs;
        foreach (var commands in progs.Keys)
            Console.WriteLine(commands);

        return true;
    }
}
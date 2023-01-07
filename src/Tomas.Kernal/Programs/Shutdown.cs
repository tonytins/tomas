using System;

namespace Tomas.Kernel.Programs;

internal class Shutdown : IProgram
{
    public bool Run(IShell shell)
    {
        Environment.Exit(Environment.ExitCode);

        return true;
    }
}

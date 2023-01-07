/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Tests.Shell;

internal class MockProgram : IProgram
{
    public bool Run(IShell shell)
    {
        Debug.WriteLine("Test Program.");
        return true;
    }
}

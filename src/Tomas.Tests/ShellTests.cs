/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
using Tomas.Tests.Shell;

namespace Tomas.Tests;

public class ShellTests
{
    // Create a new instance of the mock shell
    readonly MockShell _mockShell = new();

    [Fact]
    public void ProgramTest()
    {
        // Create a mock program
        var program = new MockProgram();

        // Assert that the Run method of the program and returns true when passed the shell object.
        Assert.True(program.Run(_mockShell));
    }

}
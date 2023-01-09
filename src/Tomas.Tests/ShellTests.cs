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
        // Create a mock program instance
        var program = new MockProgram();

        // Create a dictionary of arguments to pass to the program
        var arguments = new Dictionary<string, object>
        {
            {"arg1", "value1"},
            {"arg2", 123},
            {"arg3", true},
        };

        // Assert that the Run method of the program returns true when passed the shell object and the arguments dictionary.
        Assert.True(program.Entry(_mockShell, arguments));
    }
}
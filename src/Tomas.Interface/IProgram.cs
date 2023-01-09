/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Interface;

// Represents a program that can be run by the shell
public interface IProgram
{
    // The name of the program
    string Name { get; }

    // A description of the program
    string Description { get; }

    // The arguments that the program expects
    IEnumerable<IArguments> Arguments { get; }

    // The main entry point of the program
    // Takes a shell object to allow the program to interact with the shell,
    // and a dictionary of arguments passed to the program by the shell
    bool Entry(IShell shell, IEnumerable<KeyValuePair<string, object>> arguments);
}

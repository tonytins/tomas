/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Interface;

// Represents an argument that a program expects
public interface IArguments
{
    // The name of the argument
    string Name { get; }

    // A description of the argument
    string Description { get; }

    // The type of the argument
    Type Type { get; }

    // Whether the argument is required or optional
    bool IsRequired { get; }
}

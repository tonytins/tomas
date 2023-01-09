/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Interface;

public interface IShell
{
    string ReadLine { get; }

    Dictionary<string, IProgram> Programs { get; }

    IEnumerable<KeyValuePair<string, object>>? ParseArguments(IProgram program, string[] arguments);
}
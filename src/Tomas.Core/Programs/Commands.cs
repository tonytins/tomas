/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
namespace Tomas.Core.Programs;

public class Commands : IProgram
{
    public string Name { get; set; }

    public string Description { get; set; }

    public IEnumerable<IArguments> Arguments { get; set; }

    public bool Entry(IShell shell, IEnumerable<KeyValuePair<string, object>> arguments)
    {
        Console.WriteLine($"Commands:");
        var progs = shell.Programs;
        foreach (var commands in progs.Keys)
            Console.WriteLine(commands);
        return true;
    }
}
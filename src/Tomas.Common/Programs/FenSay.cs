// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.

using Tomas.Interface;

namespace Tomas.Common.Programs;

public class FenSay : IProgram
{

    /// <summary>
    /// Fennec art by Todd Vargo
    /// </summary>
    const string _fennec = @"                \/
   /\   /\
  //\\_//\\     ____
  \_     _/    /   /
   / * * \    /^^^]
   \_\O/_/    [   ]
    /   \_    [   /
    \     \_  /  /
     [ [ /  \/ _/
    _[ [ \  /_/";

    readonly string[] _phrases =
    {
             "[SCREAMS IN FENNEC]",
             "Some people call me a coffee fox.",
             "Drink Soda. It makes you see faster.",
             "10/10, Wouldn't Recommend."
         };

    public bool Run(IShell shell)
    {
        var rng = new Random();
        var phrases = _phrases[rng.Next(_phrases.Length)];
        Console.WriteLine($"{phrases}{Environment.NewLine}{_fennec}");
        return true;
    }
}

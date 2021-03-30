using System;
using Tomas.Interface.Shell;

namespace Tomas.Kernel.Programs
{
    public class FenSay : IProgram
    {

        /// <summary>
        /// Fennec art by Todd Vargo
        /// </summary>
        const string FENNEC = @"                \/
   /\   /\
  //\\_//\\     ____
  \_     _/    /   /
   / * * \    /^^^]
   \_\O/_/    [   ]
    /   \_    [   /
    \     \_  /  /
     [ [ /  \/ _/
    _[ [ \  /_/";

         readonly string[] _fenPhrases = { "Screams in fennec!", "Some people call me a coffee fox." };

        public bool Start()
        {
            var rng = new Random();
            var phrases = _fenPhrases[rng.Next(0, _fenPhrases.Length)];
            Console.WriteLine($"{phrases}{Environment.NewLine}{FENNEC}");
            return true;
        }
    }
}
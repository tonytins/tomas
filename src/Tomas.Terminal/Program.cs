// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
namespace Tomas.Terminal
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                var shell = new Shell();
                var command = shell.ReadLine;
                TermConsts.Programs.TryGetValue(command, out var program);
                var isRun = program.Start();

                if (isRun) continue;
                break;
            }
        }
    }
}
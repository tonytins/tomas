// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
using System;
using System.IO;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Tomas.Common;

namespace Tomas.Kernel;

class TomFS
{
    public const string ROOT_DIR = "0:\\";
    public static string SYSTEM_DIR = $"{ROOT_DIR}\\SYSTEM\\";

    public static void Initialize()
    {
        try
        {
            var fs = new CosmosVFS();
            VFSManager.RegisterVFS(fs);
            fs.CreateDirectory(SYSTEM_DIR);
            Console.WriteLine("Creating system files.");
            fs.CreateFile($"{SYSTEM_DIR}sysinfo.txt");
            Console.WriteLine("Setting system preferences.");
            File.WriteAllText($"{SYSTEM_DIR}sysinfo.txt", $"{ComConsts.NAME}, {ComConsts.VersionGit}");
            Console.WriteLine("File system loaded sucesfully.");
            var intro = File.ReadAllText($"{SYSTEM_DIR}sysinfo.txt");
            Console.WriteLine(intro);

        }
        catch
        {
            Console.WriteLine("File system failed to load! Not all functions will work.");
        }
    }

    public static string[] ListDirectories(string path)
    {
        try
        {
            var dirs = Directory.GetDirectories(path);
            return dirs;
        }
        catch
        {
            Console.WriteLine("Failed to find any directories.");
            throw;
        }
    }
}

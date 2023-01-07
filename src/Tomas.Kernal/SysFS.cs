// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.

namespace Tomas.Kernel;

static class SysFS
{
    // The root directory of the file system
    const string ROOT_DIR = "0:\\";
    // The system directory, located in the root directory
    static string SYSTEM_DIR = $"{ROOT_DIR}\\SYSTEM\\";

    static string LOG_FILE = $"{SYSTEM_DIR}system.log";

    // An instance of the CosmosVFS class, used for accessing the virtual file system
    static readonly CosmosVFS _fs = new();

    /// <summary>
    /// Initializes the file system by creating the system directory and sysinfo.txt file
    /// and setting the IsFSActive property of the SysMeta class to true
    /// </summary>
    public static void Initialize()
    {
        try
        {
            var createSysFiles = "Creating system files.";
            var setSysPref = "Writing system info.";
            var fsSuccess = "File system succesfully initialized.";

            // Register the CosmosVFS instance as the virtual file system
            VFSManager.RegisterVFS(_fs);

            // Create the system directory
            _fs.CreateDirectory(SYSTEM_DIR);

            _fs.CreateFile($"{SYSTEM_DIR}{LOG_FILE}");

            Console.WriteLine(createSysFiles);
            File.AppendAllText(LOG_FILE, createSysFiles);

            // Create the sysinfo.txt file in the system directory
            _fs.CreateFile($"{SYSTEM_DIR}sysinfo.txt");

            Console.WriteLine(setSysPref);

            File.AppendAllText(LOG_FILE, setSysPref);

            // Write the system name, version, and build number to the sysinfo.txt file
            File.WriteAllText($"{SYSTEM_DIR}sysinfo.txt", $"{SysMeta.NAME} v{SysMeta.VERSION} ({SysMeta.BuildNumber})");

            Console.WriteLine(fsSuccess);
            File.AppendAllText(LOG_FILE, fsSuccess);

            // Set the IsFSActive property of the SysMeta class to true
            SysMeta.IsFSActive = true;

            // Read the contents of the sysinfo.txt file and print it to the console
            var systemInfo = File.ReadAllText($"{SYSTEM_DIR}sysinfo.txt");

            Console.WriteLine(systemInfo);
        }
        catch (Exception err)
        {
            // If an exception is caught, print an error message indicating that the file system failed to load
            Console.WriteLine($"{err.Message}{Environment.NewLine}Warning: Error messages will not logged.");
        }
    }

    /// <summary>
    /// Creates a new directory at the specified path
    /// </summary>
    /// <param name="directory">directory</param>
    public static void CreateDirectory(string directory)
    {
        try
        {
            // Create the directory using the CosmosVFS instance
            _fs.CreateDirectory($"{ROOT_DIR}\\{directory}");
        }
        catch (IOException err)
        {
            // If an exception is caught, print an error message indicating the error
            Console.WriteLine(err.Message);
            File.AppendAllText(LOG_FILE, err.Message);
        }
    }

    /// <summary>
    /// Creates a new file at the specified path
    /// </summary>
    /// <param name="path">file path</param>
    /// <param name="file">file</param>
    public static void CreateFile(string path, string file)
    {
        try
        {
            // Create the file using the CosmosVFS instance
            _fs.CreateFile($"{ROOT_DIR}\\{path}\\{file}");
        }
        catch (IOException err)
        {
            // If an exception is caught, print an error message indicating the error
            Console.WriteLine(err.Message);
            File.AppendAllText(LOG_FILE, err.Message);
        }
    }

    /// <summary>
    /// Lists all directories in the specified path
    /// </summary>
    /// <param name="path">path to directory</param>
    /// <returns>returns a list of directories</returns>
    public static string[] ListDirectories(string path)
    {
        try
        {
            // Get the directories in the specified path using the Directory.GetDirectories method
            var dirs = Directory.GetDirectories(path);

            // Return the directories
            return dirs;
        }
        catch (IOException err)
        {
            // If an exception is caught, print an error message indicating the error
            Console.WriteLine(err.Message);
            File.AppendAllText(LOG_FILE, err.Message);

            throw;
        }
    }
}


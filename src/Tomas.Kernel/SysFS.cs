// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.

namespace Tomas.Kernel;

static class SysFS
{
    // The root directory of the file system
    public const string ROOT_DIR = "0:\\";
    // The system directory, located in the root directory
    static string SYSTEM_DIR = $"{ROOT_DIR}\\SYSTEM\\";

    static string LOG_FILE = $"{SYSTEM_DIR}system.log";

    public const string FS_ERROR = "File system disabled.";

    /// <summary>
    /// An instance of the CosmosVFS class, used for accessing the virtual file system
    /// </summary>
    static CosmosVFS fileSystem = new();

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
            var sysInfoFile = "sysinfo.txt";

            // Register the CosmosVFS instance as the virtual file system
            VFSManager.RegisterVFS(fileSystem);

            // Create the system directory
            if (!Directory.Exists(SYSTEM_DIR))
                fileSystem.CreateDirectory(SYSTEM_DIR);

            // Create the system.log file in the system directory
            if (!File.Exists($"{SYSTEM_DIR}{LOG_FILE}"))
                fileSystem.CreateFile($"{SYSTEM_DIR}{LOG_FILE}");

            Console.WriteLine(createSysFiles);
            File.AppendAllText(LOG_FILE, createSysFiles);

            // Create the sysinfo.txt file in the system directory
            if (!File.Exists($"{SYSTEM_DIR}{sysInfoFile}"))
                fileSystem.CreateFile($"{SYSTEM_DIR}{sysInfoFile}");

            Console.WriteLine(setSysPref);

            File.AppendAllText(LOG_FILE, setSysPref);

            // Write the system name, version, and build number to the sysinfo.txt file
            File.WriteAllText($"{SYSTEM_DIR}sysinfo.txt", $"{SysMeta.NAME} v{SysMeta.VERSION} ({SysMeta.BuildNumber})");

            Console.WriteLine(fsSuccess);
            File.AppendAllText(LOG_FILE, fsSuccess);

            // Set the IsFSActive property of the SysMeta class to true
            SysMeta.IsFSEnabled = true;

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
            // If file system isn't enabeld, throw exception
            if (!SysMeta.IsFSEnabled)
                throw new IOException(FS_ERROR);

            // Create the directory using the CosmosVFS instance
            if (!Directory.Exists($"{ROOT_DIR}\\{directory}"))
                fileSystem.CreateDirectory($"{ROOT_DIR}\\{directory}");
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
            // If file system isn't enabeld, throw exception
            if (!SysMeta.IsFSEnabled)
                throw new IOException(FS_ERROR);

            // Create the file using the CosmosVFS instance
            if (!File.Exists($"{ROOT_DIR}\\{path}\\{file}"))
                fileSystem.CreateFile($"{ROOT_DIR}\\{path}\\{file}");
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
            // If file system isn't enabeld, throw exception
            if (!SysMeta.IsFSEnabled)
                throw new IOException(FS_ERROR);

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


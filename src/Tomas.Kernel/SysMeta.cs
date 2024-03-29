/*
In jurisdictions that recognize copyright waivers, I've waived all copyright
and related or neighboring rights for to this project. In areas where these
waivers are not recognized, BSD-3-Clause is enforced.
See the (UN)LICENSE file in the project root for more information.
*/
using System.Text;

namespace Tomas.Kernel;

internal struct SysMeta
{
    /// <summary>
    /// The name of the operating system.
    /// </summary>
    public const string NAME = "TOMAS";

    /// <summary>
    /// The version of the operating system, in the Calendar Versioning format: "yy.minor.patch".
    /// The year, minor, and patch version numbers are automatically extracted from the Git repository
    /// using the ThisAssembly.Git.SemVer object.
    /// </summary>
    public const string VERSION = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}";

    /// <summary>
    /// The build number of the operating system, generated from the commit hash.
    /// The build number is a 6-digit number, with the first 3 digits being the first 3 digits of the commit hash
    /// converted to a uint, and the last 3 digits being the last 3 digits of the commit hash converted to a uint.
    /// </summary>
    public static string BuildNumber = $"Build {BuildNumFromCommit}";

    /// <summary>
    /// Let's the kernel know that the file system is activated.
    /// </summary>
    public static bool IsFSEnabled { get; set; } = false;

    /// <summary>
    /// Generates the build number from the commit hash.
    /// </summary>
    /// <returns>The build number as a uint.</returns>
    static uint BuildNumFromCommit
    {
        get
        {
            // Get the bytes of the commit hash as a UTF-8 encoded string
            var commit = Encoding.UTF8.GetBytes(ThisAssembly.Git.Commit);

            // Convert the first 4 bytes of the commit hash to a uint and return it modulo 1000000
            // (this will give us a 6-digit number with the first 3 digits being the first 3 digits of the commit hash
            // and the last 3 digits being the last 3 digits of the commit hash)
            return BitConverter.ToUInt32(commit, 0) % 1000000;
        }
    }
}

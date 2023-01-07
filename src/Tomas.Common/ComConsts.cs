// I license this project under the BSD 3-Clause license.
// See the LICENSE file in the project root for more information.
using System.Text;

namespace Tomas.Common;

public struct ComConsts
{
    /// <summary>
    /// Name of the operating system
    /// </summary> 
    public const string NAME = "TOMAS";
    public const string VERSION = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}";

    [SuppressMessage("Usage", "CA2211:Non-constant fields should not be visible")]
    public static string BuildNumber = $"Build {BuildFromCommit}";

    /// <summary>
    /// Generate the build number from the commit hash.
    /// </summary>
    static uint BuildFromCommit
    {
        get
        {
            var commit = Encoding.UTF8.GetBytes(ThisAssembly.Git.Commit);
            return BitConverter.ToUInt32(commit, 0) % 1000000;
        }
    }
}
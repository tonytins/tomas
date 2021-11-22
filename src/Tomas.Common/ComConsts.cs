// I license this project under the GPL 3.0 license.
// See the LICENSE file in the project root for more information.
namespace Tomas.Common;

public struct ComConsts
{
    /// <summary>
    /// Name of the operating system
    /// </summary>
    public const string NAME = "TOMAS";

    public const string Version = $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}";
    public const string VersionGit = $"{Version}-{ThisAssembly.Git.Commit}";
}

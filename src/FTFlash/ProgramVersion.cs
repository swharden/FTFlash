using System.Reflection;

namespace FTFlash;

public static class ProgramVersion
{
    public static string FullNameAndVersion => $"FTFlash v{VersionString}";

    public static string VersionString => Assembly.GetAssembly(typeof(ProgramVersion))!
    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!
    .InformationalVersion;
}

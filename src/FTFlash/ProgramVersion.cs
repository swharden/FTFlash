namespace FTFlash;

public static class ProgramVersion
{
    public const int Major = 1;
    public const int Minor = 2;
    public static string ShortString => $"{Major}.{Minor}";
    public static string FullNameAndVersion => $"FTFlash v{ShortString}";
}

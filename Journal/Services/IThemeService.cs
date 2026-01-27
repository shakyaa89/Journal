namespace Journal.Services
{
    public interface IThemeService
    {
        Task<string> GetCurrentThemeAsync();
        Task SetThemeAsync(string themeName);
    }
}

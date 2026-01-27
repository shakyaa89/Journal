
namespace Journal.Services
{
    public class ThemeService : IThemeService
    {
        private const string DefaultTheme = "dark";

        // Get the current theme
        public Task<string> GetCurrentThemeAsync()
        {
            try
            {
                var theme = Preferences.Get("theme", DefaultTheme);
                return Task.FromResult(string.IsNullOrWhiteSpace(theme) ? DefaultTheme : theme);
            }
            catch
            {
                return Task.FromResult(DefaultTheme);
            }
        }

        // Set a new theme
        public Task SetThemeAsync(string themeName)
        {
            if (string.IsNullOrWhiteSpace(themeName))
                return Task.CompletedTask;

            try
            {
                Preferences.Set("theme", themeName);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Failed to set theme preference.");
            }

            return Task.CompletedTask;
        }
    }
}

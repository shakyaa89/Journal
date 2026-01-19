
namespace Journal.Services
{
    public class ThemeService : IThemeService
    {
        private const string DefaultTheme = "dark";

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
                // swallow intentionally — theme failure should not crash app
            }

            return Task.CompletedTask;
        }
    }
}

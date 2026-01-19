using System;
using System.Collections.Generic;
using System.Text;

namespace Journal.Services
{
    public interface IThemeService
    {
        Task<string> GetCurrentThemeAsync();
        Task SetThemeAsync(string themeName);
    }
}

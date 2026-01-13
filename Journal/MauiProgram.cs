using Journal.Repositories;
using Journal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using Syncfusion.Licensing;



namespace Journal
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddSyncfusionBlazor();
            SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/VkR+XU9Ff1RAQmRWfFN0Q3NedV53fldFcC0sT3RfQFtjSH5bdkJhWXxXcnxXQWtfUw==");

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IJournalRepository, JournalRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJournalService, JournalService>();



                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("defaultConnection")));

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

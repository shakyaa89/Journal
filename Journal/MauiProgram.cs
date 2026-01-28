using Journal.Repositories;
using Journal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QuestPDF.Infrastructure;


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

            // Community license for quill.js
            QuestPDF.Settings.License = LicenseType.Community;

            builder.Services.AddMauiBlazorWebView();

            // Register theme service
            builder.Services.AddScoped<IThemeService, ThemeService>();
            // Register auth repository 
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            // Register journal repository
            builder.Services.AddScoped<IJournalRepository, JournalRepository>();
            // Register auth service
            builder.Services.AddScoped<IAuthService, AuthService>();
            // Register journal service
            builder.Services.AddScoped<IJournalService, JournalService>();
            // Register analytics service
            builder.Services.AddScoped <IAnalyticsService, AnalyticsService>();
            // Register PDF service
            builder.Services.AddSingleton<IPDFService, PDFService>();


            // Configure DbContext with PostgreSQL
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

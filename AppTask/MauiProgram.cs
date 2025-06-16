using AppTask.Database;
using AppTask.Database.Repositories;
using AppTask.Services;
using AppTask.Views;
using Microsoft.Extensions.Logging;

namespace AppTask;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        #region DI - Utilities
        builder.Services.AddScoped<HttpClient>(options =>
        {
            var client = new HttpClient() { BaseAddress = new Uri(AppSettings.EndpointAPI) };
            return client;
        });
        #endregion

        #region DI - Configuration Database
        builder.Services.AddDbContext<AppTaskContext>();
        #endregion

        #region DI - Repositories
        builder.Services.AddScoped<IUserModelRepository, UserModelRepository>();
        builder.Services.AddScoped<ITaskModelRepository, TaskModelRepository>();
        #endregion

        #region DI - Services
        builder.Services.AddScoped<IUserSevice, UserSevice>();
        builder.Services.AddScoped<ITaskService, TaskService>();
        #endregion

        #region DI - Pages
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<StartPage>();
        builder.Services.AddTransient<AddEditTaskPage>();
        #endregion

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

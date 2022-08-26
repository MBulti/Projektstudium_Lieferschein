namespace App_Lieferschein;

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

		#region Services
		
		#endregion

		#region Views
		builder.Services.AddSingleton<LoadingView>();
        builder.Services.AddSingleton<LoginView>();
        builder.Services.AddSingleton<MainView>();
        #endregion

        #region ViewModels
        builder.Services.AddTransient<LoadingViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        #endregion

        return builder.Build();
	}
}

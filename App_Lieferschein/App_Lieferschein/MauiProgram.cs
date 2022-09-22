namespace App_Lieferschein;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		#region Services
        if (App.GlobalSettings.IsMock)
        {
            builder.Services.AddSingleton<ILoginService, MockLoginService>();
            builder.Services.AddSingleton<IDataService, MockDataService>();
        } 
        else
        {
            builder.Services.AddSingleton<ILoginService, LoginService>();
            builder.Services.AddSingleton<IDataService, DataService>();
        }
        #endregion

        #region Views
        builder.Services.AddTransient<LoadingView>();
        builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<SignatureView>();
        #endregion

        #region ViewModels
        builder.Services.AddTransient<LoadingViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<SignatureViewModel>();
        #endregion

        return builder.Build();
	}
}

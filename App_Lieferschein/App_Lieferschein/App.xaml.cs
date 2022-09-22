namespace App_Lieferschein;

public partial class App : Application
{
#if DEBUG
	public static GlobalSettings GlobalSettings = new(true);
#else
	public static GlobalSettings GlobalSettings = new(false);
#endif

    public App()
	{
        // register syncfusion licence
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzIxMzQzQDMyMzAyZTMyMmUzMEw3emdRMnYzNUxaV0dPYmZGN3dMSXhlc3Y3SDZUKzRxQitrRlNGTGhmMXM9");

        InitializeComponent();

		MainPage = new AppShell();
	}
}

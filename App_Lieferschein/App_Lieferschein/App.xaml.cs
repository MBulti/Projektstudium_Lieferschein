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
		InitializeComponent();

		MainPage = new AppShell();
	}
}

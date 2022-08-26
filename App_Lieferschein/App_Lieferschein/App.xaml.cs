using App_Lieferschein.Models;

namespace App_Lieferschein;

public partial class App : Application
{
	public static GlobalSettings GlobalSettings = new();

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}

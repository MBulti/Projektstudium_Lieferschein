namespace App_Lieferschein;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(SignatureView), typeof(SignatureView));
	}
}

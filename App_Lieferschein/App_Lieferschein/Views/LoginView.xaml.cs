namespace App_Lieferschein.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
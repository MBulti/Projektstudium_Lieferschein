namespace App_Lieferschein.Views;

public partial class SignatureView : ContentPage
{
	public SignatureView(SignatureViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
namespace App_Lieferschein.Views;

public partial class LoadingView : ContentPage
{
	public LoadingView(LoadingViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}
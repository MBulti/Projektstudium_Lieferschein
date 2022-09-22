namespace App_Lieferschein.Views;

public partial class SignatureView : ContentPage
{
	public SignatureView(SignatureViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;

        DrawingViewControl.DrawAction = (canvas, rect) =>
        {
            canvas.DrawLine(20, (int)DrawingViewControl.Height - 20, (int)DrawingViewControl.Width - 20, (int)DrawingViewControl.Height - 20);
            canvas.DrawString("Unterschrift erfassen", 0, 0, (int)DrawingViewControl.Width, (int)DrawingViewControl.Height, HorizontalAlignment.Center, VerticalAlignment.Bottom);
        };
    }
}
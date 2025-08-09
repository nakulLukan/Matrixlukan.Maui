namespace Matrixlukan.Maui.Controls.Sample.Controls.Overlay;

public partial class FloatingButton : OverlayView.Control.OverlayBaseView
{
	readonly Matrixlukan.Maui.Controls.OverlayView.Core.Overlay _overlay;
	public FloatingButton(Matrixlukan.Maui.Controls.OverlayView.Core.Overlay overlay)
	{
		InitializeComponent();
        _overlay = overlay;
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		_overlay.Close();
    }
}
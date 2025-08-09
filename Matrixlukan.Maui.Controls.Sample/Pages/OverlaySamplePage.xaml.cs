using Matrixlukan.Maui.Controls.OverlayView;
using Matrixlukan.Maui.Controls.OverlayView.Core;
using Matrixlukan.Maui.Controls.OverlayView.Models;
using Matrixlukan.Maui.Controls.Sample.Controls.Overlay;

namespace Matrixlukan.Maui.Controls.Sample;

public partial class OverlaySamplePage : ContentPage
{
    public OverlaySamplePage()
    {
        InitializeComponent();
    }

    private void SharedCenterAnchorPositionProportional_Clicked(object sender, EventArgs e)
    {
        Overlay.Shared.Open(new MyCustomizedOverlay(), Anchor.Center, new LayoutBounds(0.5, 0.5), LayoutFlags.PositionProportional);
    }

    private void SharedCenterAnchorPositionProportionalBottom_Clicked(object sender, EventArgs e)
    {
        Overlay.Shared.Open(new MyCustomizedOverlay(), Anchor.Bottom, new LayoutBounds(0.5, 1), LayoutFlags.PositionProportional);
    }

    private void SharedBottomLeftAnchorPositionProportionalBottom_Clicked(object sender, EventArgs e)
    {
        Overlay.Shared.Open(new MyCustomizedOverlay(), Anchor.BottomLeft, new LayoutBounds(0, 1, 1, LayoutBounds.AutoSize), LayoutFlags.PositionProportional, LayoutFlags.WidthProportional);
    }

    private void SharedTopLeftAnchorFixedWidthFullHeight_Clicked(object sender, EventArgs e)
    {
        Overlay.Shared.Open(new MyCustomizedOverlay(), Anchor.TopLeft, new LayoutBounds(0, 0, 100, 1), LayoutFlags.PositionProportional, LayoutFlags.HeightProportional);
    }

    private void Close_Clicked(object sender, EventArgs e)
    {
        Overlay.Shared.Close();
    }

    private void ToastClicked(object sender, EventArgs e)
    {
        Overlay.Shared.Open(new CustomSnackbar("This is my custom snackbar", "dotnet_bot.png", Overlay.Shared), Anchor.Bottom, new LayoutBounds(0.5, 1), LayoutFlags.PositionProportional);
    }
}
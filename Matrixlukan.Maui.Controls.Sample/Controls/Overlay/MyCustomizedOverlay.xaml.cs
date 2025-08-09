
using CommunityToolkit.Maui.Alerts;

namespace Matrixlukan.Maui.Controls.Sample.Controls.Overlay;

public partial class MyCustomizedOverlay : OverlayView.Control.OverlayBaseView
{
    public MyCustomizedOverlay()
    {
        InitializeComponent();
    }

    public override void OnClose()
    {
        var toast = Toast.Make("Overlay Closed", CommunityToolkit.Maui.Core.ToastDuration.Short);
        toast.Show();
    }

    public override void OnOpen()
    {
    }
}
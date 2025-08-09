using CoreGraphics;
using Matrixlukan.Maui.Controls.OverlayView.Control;
using Matrixlukan.Maui.Controls.OverlayView.Models;
using Microsoft.Maui.Platform;
using UIKit;

namespace Matrixlukan.Maui.Controls.OverlayView.Core;

public partial class Overlay
{
    private OverlayBaseView? _view;
    private UIView? _nativeView;

    public partial void Open(OverlayBaseView view, Anchor anchor, LayoutBounds layoutBounds, params LayoutFlags[] layoutFlags)
    {
#pragma warning disable CA1422 // Validate platform compatibility
        var window = UIApplication.SharedApplication?.KeyWindow;
#pragma warning restore CA1422 // Validate platform compatibility
        if (window == null) return;

        // Remove existing view if present. If another view is shown before any existing one is dismissed, it can cause issues.
        if (_view != null && _nativeView != null)
        {
            Close();
        }

        _view = view;
        _nativeView = _view.ToPlatform(Application.Current!.Handler.MauiContext!)!;

        var screenWidth = window.Bounds.Width;
        var screenHeight = window.Bounds.Height;

        // Measure view size
        var fittingSize = _nativeView.SizeThatFits(new CGSize(nfloat.MaxValue, nfloat.MaxValue));

        // Get size based on layout bounds and flags
        double width = layoutFlags.Contains(LayoutFlags.WidthProportional) && layoutBounds.Width >= 0 ? screenWidth * layoutBounds.Width : layoutBounds.Width >= 0 ? layoutBounds.Width : fittingSize.Width;
        double height = layoutFlags.Contains(LayoutFlags.HeightProportional) && layoutBounds.Height >= 0 ? screenHeight * layoutBounds.Height : layoutBounds.Height >= 0 ? layoutBounds.Height : fittingSize.Height;

        var offset = GetAnchorOffset(width, height, anchor);
        _nativeView.Frame = new CoreGraphics.CGRect(
            (GetX(screenWidth, layoutBounds, layoutFlags) + offset.X),
            (GetY(screenHeight, layoutBounds, layoutFlags) + offset.Y),
            width,
            height);

        window.AddSubview(_nativeView);
        _view.OnOpen();
    }

    public partial void Close()
    {
        if (_view != null)
        {
            _view.Close();
        }

        _nativeView?.RemoveFromSuperview();
        _nativeView = null;
    }
}

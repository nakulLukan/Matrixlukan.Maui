using Android.Views;
using Android.Widget;
using Matrixlukan.Maui.Controls.OverlayView.Control;
using Matrixlukan.Maui.Controls.OverlayView.Models;
using Microsoft.Maui.Platform;

namespace Matrixlukan.Maui.Controls.OverlayView.Core;

public partial class Overlay
{
    private OverlayBaseView? _view;
    private ViewGroup? _decorView;
    private Android.Views.View? _nativeView;
    public partial void Open(OverlayBaseView view, Anchor anchor, LayoutBounds layoutBounds, params LayoutFlags[] layoutFlags)
    {
        var activity = Platform.CurrentActivity;
        if (activity == null) return;

        _decorView = activity.Window?.DecorView as ViewGroup;
        if (_decorView == null) return;

        // Remove existing view if present. If another view is shown before any existing one is dismissed, it can cause issues.
        if (_view != null && _nativeView != null)
        {
            Close();
        }
        _view = view;

        var screenWidth = (activity!.Window!.DecorView.Width);
        var screenHeight = (activity!.Window!.DecorView.Height);
        _nativeView = _view.ToPlatform(Application.Current!.Handler.MauiContext!)!;
        
        // Measure size of the view
        int widthSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
        int heightSpec = Android.Views.View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
        _nativeView.Measure(widthSpec, heightSpec);

        // Get size based on layout bounds and flags
        double width = layoutFlags.Contains(LayoutFlags.WidthProportional) && layoutBounds.Width >= 0 ? screenWidth * layoutBounds.Width : layoutBounds.Width >= 0 ? layoutBounds.Width : _nativeView.MeasuredWidth;
        double height = layoutFlags.Contains(LayoutFlags.HeightProportional) && layoutBounds.Height >= 0 ? screenHeight * layoutBounds.Height : layoutBounds.Height >= 0 ? layoutBounds.Height : _nativeView.MeasuredHeight;
        
        // Find offset to adjust X and Y to place them correctly
        var offset = GetAnchorOffset(width, height, anchor);
        var layoutParams = new FrameLayout.LayoutParams((int)width, (int)height)
        {
            LeftMargin = (int)(GetX(screenWidth, layoutBounds, layoutFlags) + offset.X),
            TopMargin = (int)(GetY(screenHeight, layoutBounds, layoutFlags) + offset.Y)
        };

        // Add it to decor view
        _decorView.AddView(_nativeView, layoutParams);

        // Invoke the view appearing method
        _view.Invoke();
    }

    public partial void Close()
    {
        if (_view != null)
        {
            _view.Close();
        }

        if (_decorView != null && _nativeView != null)
            _decorView.RemoveView(_nativeView);
        _nativeView = null;
    }
}

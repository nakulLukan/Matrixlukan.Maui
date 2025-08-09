using Matrixlukan.Maui.Controls.OverlayView.Control;
using Matrixlukan.Maui.Controls.OverlayView.Models;

namespace Matrixlukan.Maui.Controls.OverlayView.Core;

public partial class Overlay
{
    private static Overlay _shared = new Overlay();
    public static Overlay Shared { get => _shared; }

    public partial void Open(OverlayBaseView view, Anchor anchor, LayoutBounds layoutBounds, params LayoutFlags[] layoutFlags);
    public partial void Close();

    /// <summary>
    /// Get the X position relative to bounds and flags
    /// </summary>
    /// <param name="screenWidth"></param>
    /// <param name="bounds"></param>
    /// <param name="layoutFlags"></param>
    /// <returns></returns>
    static double GetX(double screenWidth, LayoutBounds bounds, params LayoutFlags[] layoutFlags)
    {
        if (layoutFlags.Any(x => x == LayoutFlags.XProportional || x == LayoutFlags.PositionProportional))
        {
            return screenWidth * bounds.X;
        }

        return bounds.X;
    }

    /// <summary>
    /// Get the Y position relative to bounds and flags
    /// </summary>
    /// <param name="screenHeight"></param>
    /// <param name="bounds"></param>
    /// <param name="layoutFlags"></param>
    /// <returns></returns>
    static double GetY(double screenHeight, LayoutBounds bounds, params LayoutFlags[] layoutFlags)
    {
        if (layoutFlags.Any(x => x == LayoutFlags.YProportional || x == LayoutFlags.PositionProportional))
        {
            return screenHeight * bounds.Y;
        }

        return bounds.Y;
    }

    /// <summary>
    /// Get view anchor
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="anchor"></param>
    /// <returns></returns>
    static (double X, double Y) GetAnchorOffset(double width, double height, Anchor anchor)
    {
        switch (anchor)
        {
            case Anchor.TopLeft: return (0, 0);
            case Anchor.TopRight: return (-width, 0);
            case Anchor.BottomLeft: return (0, -height);
            case Anchor.BottomRight: return (-width, -height);
            case Anchor.Left: return (0, -height / 2);
            case Anchor.Right: return (-width, -height / 2);
            case Anchor.Top: return (-width / 2, 0);
            case Anchor.Bottom: return (-width / 2, -height);
            default: return (-width / 2, -height / 2);
        }

    }
}

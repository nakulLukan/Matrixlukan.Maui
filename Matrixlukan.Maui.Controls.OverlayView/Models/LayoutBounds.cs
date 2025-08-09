namespace Matrixlukan.Maui.Controls.OverlayView.Models;

public class LayoutBounds
{
    public double X { get; set; } = 0;
    public double Y { get; set; } = 0;
    public double Width { get; set; } = AutoSize;
    public double Height { get; set; } = AutoSize;

    public const double AutoSize = -1;


    public LayoutBounds(double x, double y)
    {
        Y = y;
        X = x;
    }


    public LayoutBounds(double x, double y, double width, double height)
    {
        Y = y;
        X = x;

        Width = width;
        Height = height;
    }
}

namespace Matrixlukan.Maui.Controls.Sample.Controls.Overlay;

public partial class CustomSnackbar : OverlayView.Control.OverlayBaseView
{
    private readonly OverlayView.Core.Overlay _overlayInstance;
    System.Timers.Timer _timer;
    public CustomSnackbar(string toastMessage, string iconSource, Matrixlukan.Maui.Controls.OverlayView.Core.Overlay overlayInstance)
    {
        InitializeComponent();
        imgIcon.Source = iconSource;
        lblMessage.Text = toastMessage;
        _overlayInstance = overlayInstance;
        _timer = new System.Timers.Timer(3000);
        _timer.Elapsed += TimerElapsed;
        _timer.Start();
    }

    private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
    {
        Dispose();
    }

    private void Close_Clicked(object sender, EventArgs e)
    {
        Dispose();
    }

    private void Dispose()
    {
        _timer.Stop();
        _timer.Dispose();
        _overlayInstance.Close();
    }
}
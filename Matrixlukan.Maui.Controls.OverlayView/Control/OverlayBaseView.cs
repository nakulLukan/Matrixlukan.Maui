namespace Matrixlukan.Maui.Controls.OverlayView.Control;

public abstract class OverlayBaseView : ContentView
{
    public virtual void OnOpen() { }
    public virtual void OnClose() { }
    internal void Invoke()
    {
        OnOpen();
    }

    internal void Close()
    {
        OnClose();
    }
}

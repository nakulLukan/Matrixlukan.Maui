using Matrixlukan.Maui.Controls.OverlayView;
using Matrixlukan.Maui.Controls.Sample.Controls.Overlay;

namespace Matrixlukan.Maui.Controls.Sample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void Button_GotoSamplePageClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync($"/{nameof(OverlaySamplePage)}");
        }
    }
}

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExampleSwitchesPage : ContentPage
    {
        public ExampleSwitchesPage()
        {
            InitializeComponent();

            _switchIos.SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                Color fromColor = e.IsToggled ? Color.FromHex("#4ACC64") : Color.FromHex("#EBECEC");
                Color toColor = e.IsToggled ? Color.FromHex("#EBECEC") : Color.FromHex("#4ACC64");

                double t = e.Percentage * 0.01;

                _switchIos.BackgroundColor = ColorAnimation(fromColor, toColor, t);
            };
        }

        Color ColorAnimation(Color fromColor, Color toColor, double t)
        {
            return Color.FromRgba(fromColor.R + t * (toColor.R - fromColor.R),
                fromColor.G + t * (toColor.G - fromColor.G),
                fromColor.B + t * (toColor.B - fromColor.B),
                fromColor.A + t * (toColor.A - fromColor.A));
        }
    }
}
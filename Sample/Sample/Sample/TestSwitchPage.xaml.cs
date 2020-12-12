using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestSwitchPage : ContentPage
    {
        public TestSwitchPage()
        {
            InitializeComponent();

            Switch1.SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                var fromColor = e.IsToggled ? Color.FromHex("#4ACC64") : Color.FromHex("#EBECEC");
                var toColor = e.IsToggled ? Color.FromHex("#EBECEC") : Color.FromHex("#4ACC64");

                var t = e.Percentage * 0.01;

                Switch1.BackgroundColor = ColorAnimation(fromColor, toColor, t);
            };

            Switch2.SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                var fromColor = e.IsToggled ? Color.FromHex("#4ACC64") : Color.FromHex("#EBECEC");
                var toColor = e.IsToggled ? Color.FromHex("#EBECEC") : Color.FromHex("#4ACC64");

                var t = e.Percentage * 0.01;

                Switch2.BackgroundColor = ColorAnimation(fromColor, toColor, t);
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
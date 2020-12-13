using System.Diagnostics.CodeAnalysis;
using Switch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public partial class IosSwitch : TestSwitch
    {
        public IosSwitch()
        {
            InitializeComponent();

            SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                Color fromColor = IsToggled ? Color.FromHex("#4ACC64") : Color.FromHex("#EBECEC");
                Color toColor = IsToggled ? Color.FromHex("#EBECEC") : Color.FromHex("#4ACC64");

                double t = e.Percentage * 0.01;

                BackgroundColor = ColorAnimation(fromColor, toColor, t);
            };
        }

        private Color ColorAnimation(Color fromColor, Color toColor, double t)
        {
            return Color.FromRgba(fromColor.R + t * (toColor.R - fromColor.R),
                fromColor.G + t * (toColor.G - fromColor.G),
                fromColor.B + t * (toColor.B - fromColor.B),
                fromColor.A + t * (toColor.A - fromColor.A));
        }
    }
}
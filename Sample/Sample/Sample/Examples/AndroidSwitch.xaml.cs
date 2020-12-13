using Switch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AndroidSwitch : TestSwitch
    {
        public AndroidSwitch()
        {
            InitializeComponent();

            SwitchPanUpdate += (sender, e) =>
            {
                //Switch Color Animation
                Color fromSwitchColor = e.IsToggled ? Color.FromHex("#239385") : Color.FromHex("#fafafa");
                Color toSwitchColor = e.IsToggled ? Color.FromHex("#fafafa") : Color.FromHex("#239385");

                //BackGroundColor Animation
                Color fromColor = e.IsToggled ? Color.FromHex("#A6D3CF") : Color.FromHex("#A6A6A6");
                Color toColor = e.IsToggled ? Color.FromHex("#A6A6A6") : Color.FromHex("#A6D3CF");

                double t = e.Percentage * 0.01;

                KnobColor = ColorAnimation(fromSwitchColor, toSwitchColor, t);
                BackgroundColor = ColorAnimation(fromColor, toColor, t);
            };
        }

        private Color ColorAnimation(Color fromColor, Color toColor, double t)
        {
            return Color.FromRgba(fromColor.R + (t * (toColor.R - fromColor.R)),
                fromColor.G + (t * (toColor.G - fromColor.G)),
                fromColor.B + (t * (toColor.B - fromColor.B)),
                fromColor.A + (t * (toColor.A - fromColor.A)));
        }
    }
}
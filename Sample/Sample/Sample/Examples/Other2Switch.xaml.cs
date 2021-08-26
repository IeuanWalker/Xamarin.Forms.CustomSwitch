using Switch;
using Switch.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Other2Switch : CustomSwitch
    {
        public Other2Switch()
        {
            InitializeComponent();
            SwitchPanUpdate += (sender, e) =>
            {
                Color fromColorGradient1 = IsToggled ? Color.FromHex("#a8ff78") : Color.FromHex("#FF512F");
                Color toColorGradient1 = IsToggled ? Color.FromHex("#FF512F") : Color.FromHex("#a8ff78");

                Color fromColorGradient2 = IsToggled ? Color.FromHex("#78ffd6") : Color.FromHex("#DD2476");
                Color toColorGradient2 = IsToggled ? Color.FromHex("#DD2476") : Color.FromHex("#78ffd6");

                double t = e.Percentage * 0.01;

                KnobBackground = new LinearGradientBrush(new GradientStopCollection
                {
                    new GradientStop
                    {
                        Color =  ColorAnimationUtil.ColorAnimation(fromColorGradient1, toColorGradient1, t),
                        Offset = 0
                    },
                    new GradientStop
                    {
                        Color = ColorAnimationUtil.ColorAnimation(fromColorGradient2, toColorGradient2, t),
                        Offset = 1
                    }
                }, new Point(0.6, 1), new Point(1,0));
            };
        }
    }
}
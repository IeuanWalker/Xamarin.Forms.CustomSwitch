using Switch;
using Switch.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeStyle2Switch : CustomSwitch
    {
        public ThemeStyle2Switch()
        {
            InitializeComponent();
            SwitchPanUpdate += (sender, e) =>
            {
                Color fromColorGradient1 = IsToggled ? Color.FromHex("#16d4f4") : Color.FromHex("#4a467e");
                Color toColorGradient1 = IsToggled ? Color.FromHex("#4a467e") : Color.FromHex("#16d4f4");

                Color fromColorGradient2 = IsToggled ? Color.FromHex("#cffdfc") : Color.FromHex("#21103a");
                Color toColorGradient2 = IsToggled ? Color.FromHex("#21103a") : Color.FromHex("#cffdfc");

                double t = e.Percentage * 0.01;

                Flex.TranslationX = -(e.TranslateX + e.XRef);
                BackgroundColorGradientStops = new Xamarin.Forms.PancakeView.GradientStopCollection
                {
                    new Xamarin.Forms.PancakeView.GradientStop
                    {
                        Color =  ColorAnimationUtil.ColorAnimation(fromColorGradient1, toColorGradient1, t),
                        Offset = 0
                    },
                    new Xamarin.Forms.PancakeView.GradientStop
                    {
                        Color = ColorAnimationUtil.ColorAnimation(fromColorGradient2, toColorGradient2, t),
                        Offset = 1
                    }
                };
            };
        }
    }
}
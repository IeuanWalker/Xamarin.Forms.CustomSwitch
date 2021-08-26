using Switch;
using Switch.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Theme2Switch : CustomSwitch
    {
        public Theme2Switch()
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
                if (IsToggled)
                {
                    if (e.Percentage >= 50)
                    {
                        MoonImg.Opacity = ((e.Percentage - 50) * 2) * 0.01;
                    }
                }
                else
                {
                    if (e.Percentage <= 50)
                    {
                        MoonImg.Opacity = (100 - (e.Percentage * 2)) * 0.01;
                    }
                }

                Background = new LinearGradientBrush(new GradientStopCollection
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
                });
            };
        }
    }
}
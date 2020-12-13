using Switch;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnOffTabSwitch : TestSwitch
    {
        public OnOffTabSwitch()
        {
            InitializeComponent();
            SwitchPanUpdate += (sender, e) =>
           {
               Flex.TranslationX = -(e.TranslateX + e.xRef);

               Color fromColorLight = IsToggled ? Color.FromHex("#cdf4cc") : Color.FromHex("#f7cccc");
               Color toColorLight = IsToggled ? Color.FromHex("#f7cccc") : Color.FromHex("#cdf4cc");

               Color fromColorDark = IsToggled ? Color.FromHex("#46d744") : Color.FromHex("#dd2424");
               Color toColorDark = IsToggled ? Color.FromHex("#dd2424") : Color.FromHex("#46d744");

               double t = e.Percentage * 0.01;


               KnobCornerRadius = IsToggled ? new CornerRadius(0, 5, 0, 5) : new CornerRadius(5, 0, 5, 0);
               KnobColor = ColorAnimation(fromColorLight, toColorLight, t);
               KnobBorder.Color = ColorAnimation(fromColorDark, toColorDark, t);
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
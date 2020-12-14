using Switch;
using Switch.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeStyle1Switch : CustomSwitch
    {
        public ThemeStyle1Switch()
        {
            InitializeComponent();
            SwitchPanUpdate += (sender, e) =>
            {
                Color fromBackgroundColor = IsToggled ? Color.FromHex("#001f48") : Color.White;
                Color toBackgroundColor = IsToggled ? Color.White : Color.FromHex("#001f48");

                Color fromBorderColor = IsToggled ? Color.FromHex("#16447a") : Color.FromHex("#f1ca1b");
                Color toBorderColor = IsToggled ? Color.FromHex("#f1ca1b") : Color.FromHex("#16447a");

                double t = e.Percentage * 0.01;

                Flex.TranslationX = -(e.TranslateX + e.XRef);
                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromBackgroundColor, toBackgroundColor, t);
                Border = new Border
                {
                    Color = ColorAnimationUtil.ColorAnimation(fromBorderColor, toBorderColor, t),
                    Thickness = 5
                };
            };
        }
    }
}
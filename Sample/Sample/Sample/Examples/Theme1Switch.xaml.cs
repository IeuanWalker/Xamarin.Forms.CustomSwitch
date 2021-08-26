using Switch;
using Switch.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Theme1Switch : CustomSwitch
    {
        public Theme1Switch()
        {
            InitializeComponent();
            SwitchPanUpdate += (sender, e) =>
            {
                Color fromBackgroundColor = IsToggled ? Color.FromHex("#001f48") : Color.White;
                Color toBackgroundColor = IsToggled ? Color.White : Color.FromHex("#001f48");

                double t = e.Percentage * 0.01;

                Flex.TranslationX = -(e.TranslateX + e.XRef);
                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromBackgroundColor, toBackgroundColor, t);
            };
        }
    }
}
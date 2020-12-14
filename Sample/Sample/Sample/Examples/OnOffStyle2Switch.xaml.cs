using Switch;
using Switch.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnOffStyle2Switch : CustomSwitch
    {
        public OnOffStyle2Switch()
        {
            InitializeComponent();
            SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                Color fromColor = IsToggled ? Color.FromHex("#33b68d") : Color.FromHex("#e7640f");
                Color toColor = IsToggled ? Color.FromHex("#e7640f") : Color.FromHex("#33b68d");

                double t = e.Percentage * 0.01;

                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
            };
        }
    }
}
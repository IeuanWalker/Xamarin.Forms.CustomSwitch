using Switch;
using Switch.Helpers;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
    public partial class IosSwitch : CustomSwitch
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

                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
            };
        }
    }
}
using Switch.Helpers;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Test.SwitchPanUpdate += (sender, e) =>
            {
                //Switch Color Animation
                Color fromSwitchColor = e.IsToggled ? Color.FromHex("#6200ee") : Color.FromHex("#fafafa");
                Color toSwitchColor = e.IsToggled ? Color.FromHex("#fafafa") : Color.FromHex("#6200ee");

                //BackGroundColor Animation
                Color fromColor = e.IsToggled ? Color.FromHex("#a472ea") : Color.FromHex("#9b9b9b");
                Color toColor = e.IsToggled ? Color.FromHex("#9b9b9b") : Color.FromHex("#a472ea");

                double t = e.Percentage * 0.01;

                Test.KnobColor = ColorAnimationUtil.ColorAnimation(fromSwitchColor, toSwitchColor, t);
                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
            };
        }

    }
}
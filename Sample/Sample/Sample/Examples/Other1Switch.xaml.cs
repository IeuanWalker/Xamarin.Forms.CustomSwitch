﻿using Switch;
using Switch.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Other1Switch : CustomSwitch
    {
        public Other1Switch()
        {
            InitializeComponent();
            SwitchPanUpdate += (sender, e) =>
            {
                Flex.TranslationX = -(e.TranslateX + e.XRef);

                Color fromColorLight = IsToggled ? Color.FromHex("#cdf4cc") : Color.FromHex("#f7cccc");
                Color toColorLight = IsToggled ? Color.FromHex("#f7cccc") : Color.FromHex("#cdf4cc");

                double t = e.Percentage * 0.01;

                KnobCornerRadius = IsToggled ? new CornerRadius(0, 5, 0, 5) : new CornerRadius(5, 0, 5, 0);
                KnobColor = ColorAnimationUtil.ColorAnimation(fromColorLight, toColorLight, t);
            };
        }
    }
}
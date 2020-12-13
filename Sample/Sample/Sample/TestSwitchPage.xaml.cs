﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestSwitchPage : ContentPage
    {
        public TestSwitchPage()
        {
            InitializeComponent();

            OnOffSwitch.SwitchPanUpdate += (sender, e) =>
            {
                Flex.TranslationX = -(e.TranslateX + e.xRef);
            };
        }
    }
}
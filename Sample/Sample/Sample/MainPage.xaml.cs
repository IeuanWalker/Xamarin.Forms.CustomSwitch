﻿using System;
using Acr.UserDialogs;
using Sample.Pages;
using Sample.ViewModels;
using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MainViewModel();
        }

        private async void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            if (_viewModel.EnableEvents)
            {
                await UserDialogs.Instance.AlertAsync($"New value: {e.Value}", "Switch toggled (Event)").ConfigureAwait(false);
            }
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AccessibilityTestPage());
        }
    }
}
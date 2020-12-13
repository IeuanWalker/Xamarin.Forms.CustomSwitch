using Xamarin.Forms;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ExampleSwitchesPage());
        }

        private async void Button_Clicked_1(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new TestSwitchPage());
        }
    }
}
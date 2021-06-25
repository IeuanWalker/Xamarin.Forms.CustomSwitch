using Xamarin.Forms;

[assembly: ExportFont("FA-Solid-900.otf", Alias = "FontAwesome")]

namespace Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
using Switch;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Other5Switch : CustomSwitch
    {
        public Other5Switch()
        {
            InitializeComponent();

            SwitchPanUpdate += (sender, e) => Flex.TranslationX = -(e.TranslateX + e.XRef);
        }
    }
}
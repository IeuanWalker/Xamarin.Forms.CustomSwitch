using Switch;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Other4Switch : CustomSwitch
    {
        public Other4Switch()
        {
            InitializeComponent();

            SwitchPanUpdate += (sender, e) => Flex.TranslationX = -(e.TranslateX + e.XRef);
        }
    }
}
using Switch;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TickCrossSwitch : CustomSwitch
    {
        public TickCrossSwitch()
        {
            InitializeComponent();

            SwitchPanUpdate += (sender, e) => Flex.TranslationX = -(e.TranslateX + e.XRef);
        }
    }
}
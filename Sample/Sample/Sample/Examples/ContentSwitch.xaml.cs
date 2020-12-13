using Switch;
using Xamarin.Forms.Xaml;

namespace Sample.Examples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContentSwitch : TestSwitch
    {
        public ContentSwitch()
        {
            InitializeComponent();


            SwitchPanUpdate += (sender, e) =>
            {
                Flex.TranslationX = -(e.TranslateX + e.xRef);
            };
        }
    }
}
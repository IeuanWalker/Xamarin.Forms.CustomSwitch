using Acr.UserDialogs;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ToggleCommand = new Command<bool>(async x => await Toggled(x).ConfigureAwait(false));
        }

        public bool EnableCommands { get; set; }
        public bool EnableEvents { get; set; }

        public ICommand ToggleCommand { get; }

        public async Task Toggled(bool newValue)
        {
            if (EnableCommands)
            {
                await UserDialogs.Instance.AlertAsync($"New value: {newValue}", "Switch toggled (Command)").ConfigureAwait(false);
            }
        }
    }
}
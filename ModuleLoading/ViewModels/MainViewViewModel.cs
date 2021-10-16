using Prism.Navigation;

namespace ModuleLoading.ViewModels
{
    public class MainViewViewModel :ViewModelBase
    {
        public MainViewViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "This is from the VM.";
        }
    }
}

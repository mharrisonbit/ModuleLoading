using System;
namespace ListDisplayModule.ViewModels
{
    public class ListDisplayMainViewModel : ViewModelBase
    {
        public ListDisplayMainViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoBackBtn = new DelegateCommand(GoBackCmd);
        }

        private DelegateCommand GoBackBtn { get; set; }

        private void GoBackCmd()
        {
            this.NavigationService.GoBackAsync();
        }
    }
}

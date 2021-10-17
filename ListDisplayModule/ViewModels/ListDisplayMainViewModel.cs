using System.Collections.ObjectModel;
using ListDisplayModule.Models;
using Prism.Commands;
using Prism.Navigation;

namespace ListDisplayModule.ViewModels
{
    public class ListDisplayMainViewModel : ViewModelBase, INavigationAware
    {
        public DelegateCommand GoBackBtn { get; private set; }

        public ListDisplayMainViewModel(INavigationService navigationService) : base(navigationService)
        {
            GoBackBtn = new DelegateCommand(GoBackCmd);
        }

        ObservableCollection<Merchant> _MerchantCollection;
        public ObservableCollection<Merchant> MerchantCollection
        {
            get { return _MerchantCollection; }
            set { SetProperty(ref _MerchantCollection, value); }
        }

        private void GoBackCmd()
        {
            this.NavigationService.GoBackAsync();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var merchantsString = parameters.GetValue<string>("merchants_json");

            MerchantCollection = Merchant.FromJson(merchantsString);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }
    }
}

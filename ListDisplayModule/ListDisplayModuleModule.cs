using ListDisplayModule.ViewModels;
using ListDisplayModule.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace ListDisplayModule
{
    public class ListDisplayModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ListDisplayMainView, ListDisplayMainViewModel>();
        }
    }
}
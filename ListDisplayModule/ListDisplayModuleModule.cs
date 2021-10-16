using System;
using ListDisplayModule.ViewModels;

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
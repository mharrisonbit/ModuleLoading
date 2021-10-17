using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Modularity;
using Prism.Navigation;

namespace ModuleLoading.ViewModels
{
    public class MainViewViewModel :ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IModuleManager moduleManager;
        public DelegateCommand LoadModuleBtn { get; private set; }
        public DelegateCommand CallModuleBtn { get; private set; }

        public MainViewViewModel(INavigationService navigationService, IModuleManager moduleManager) : base(navigationService)
        {
            this.navigationService = navigationService;
            this.moduleManager = moduleManager;
            Title = "This is from the VM.";
            LoadModuleBtn = new DelegateCommand(LoadModuleCmd);
            CallModuleBtn = new DelegateCommand(async () => await CallModuleCmd());
        }

        bool _ModuleLoaded;
        public bool ModuleLoaded
        {
            get { return _ModuleLoaded; }
            set { SetProperty(ref _ModuleLoaded, value); }
        }

        private void LoadModuleCmd()
        {
            this.moduleManager.LoadModuleCompleted += ModuleManager_LoadModuleCompleted;
            this.moduleManager.LoadModule("ListDisplayModuleModule");
        }

        private void ModuleManager_LoadModuleCompleted(object sender, LoadModuleCompletedEventArgs e)
        {
            ModuleLoaded = true;
            Console.WriteLine(sender);
            Console.WriteLine(e);
        }

        private async Task CallModuleCmd()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Short_json_test.txt");

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainViewViewModel)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("ModuleLoading.JsonFiles.Short_json_test.txt");
            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }

            var navigationParams = new NavigationParameters
            {
                { "merchants_json", text }
            };

            await navigationService.NavigateAsync("ListDisplayMainView", navigationParams);
        }
    }
}
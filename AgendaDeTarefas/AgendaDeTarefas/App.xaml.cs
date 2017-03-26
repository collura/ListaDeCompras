using Prism.Unity;
using Xamarin.Forms;
using System;
using Prism.Navigation;

namespace ListaDeCompras
{

       public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {           
            InitializeComponent();
            NavigationService.NavigateAsync("NavigationPage/MainPage");       
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<EditionPage>();
        }
    }
}

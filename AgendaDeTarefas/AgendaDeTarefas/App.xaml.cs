using Prism.Unity;
using AgendaDeTarefas.Views;
using Xamarin.Forms;
using System;
using Prism.Navigation;



namespace AgendaDeTarefas
{


    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected async override void OnInitialized()
        {
           
            //MainPage = new NavigationPage(new MainPage());
            InitializeComponent();
            await NavigationService.NavigateAsync("MainPage ? title = FirstPage");

        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<EditionPage>();
        }
    }
}

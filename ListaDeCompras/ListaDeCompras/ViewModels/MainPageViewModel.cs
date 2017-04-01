using ListaDeCompras.Storage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListaDeCompras
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService navigationService { get; set; }
        private ItemDirectory loadedItens { get; set; }
        private DatabaseManager database { get; set; }
        private IPageDialogService DialogService { get; set; }
        private NavigationParameters navigationParameters;
        public ObservableCollection<Item> ItensToListView { get; set; }  
        public DelegateCommand AddItem { get; private set; }
        public ICommand SalvarLista { get; private set; }
        

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            ItensToListView = new ObservableCollection<Item>();           
            LoadList();
            database = new DatabaseManager();           
            this.navigationService = navigationService;
            this.DialogService = dialogService;
            AddItem = new DelegateCommand(() => _addItem());
            SalvarLista = new DelegateCommand(() => _salvarLista());                        
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            return;
        }
    

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            return;
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            return;
        }
    

        private void LoadList() {
            loadedItens = ItemService.LoadItens();
            foreach (var item in loadedItens.ItensList)
                    ItensToListView.Add(item);            
        }


        private async void _addItem() {
            //navigationParameters = new NavigationParameters();
            //navigationParameters.Add("ItensToListView", ItensToListView);   
            await navigationService.NavigateAsync("EditionPage");
            MessagingCenter.Send(this,"collection", ItensToListView);

        }

        private async void _salvarLista() {
            await DialogService.DisplayAlertAsync("Lista Salva Com sucesso !", "", "Ok");
        }        
    }
}

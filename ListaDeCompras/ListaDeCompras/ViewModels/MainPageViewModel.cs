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
    public class MainPageViewModel : BindableBase
    {
        private INavigationService navigationService { get; set; }        
        private bool IsBusy { get; set; }
        private ItemDirectory loadedItens { get; set; }
        private DatabaseManager DbManager { get; set; }
        private IPageDialogService DialogService { get; set; }
        private NavigationParameters navigationParameters;
        public ObservableCollection<Item> ItensToListView { get; set; }
        public DelegateCommand AddItem { get; private set; }
        public ICommand SaveList { get; private set; }
        public ICommand ItemClick { get; private set; }
        public ICommand DelItem { get; private set; }
        public ICommand RecoverList { get; private set; }
        private Item _selectItem;
        public Item SelectItem
        {
            get { return _selectItem; }
            set { SetProperty(ref _selectItem, value); }
        }


        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            //Teste
            IsBusy = false;
            ItensToListView = new ObservableCollection<Item>();
            //LoadList();
            DbManager = new DatabaseManager();
            this.navigationService = navigationService;
            this.DialogService = dialogService;
            AddItem = new DelegateCommand(() => _addItem());
            ItemClick = new Command((object obj) => _itemClick(obj));
            DelItem = new Command(() => _deleteItemDb());
            RecoverList = new Command(() => _recoverList());
            SaveList = new DelegateCommand(() => _saveList());                        
        }


        private void LoadList()
        {
            loadedItens = ItemService.LoadItens();
            foreach (var item in loadedItens.ItensList)
                ItensToListView.Add(item);
        }


        private async void _addItem()
        {
            navigationParameters = new NavigationParameters();
            navigationParameters.Add("ItensToListView", ItensToListView);
            await navigationService.NavigateAsync("EditionPage", navigationParameters);
            MessagingCenter.Send(this, "teste", ItensToListView);
        }


        private async void _saveList()
        {
            if(ItensToListView.Count > 0) { 
            ListItems list = new ListItems();
            list.Descricao = "Lista";
                if (ItensToListView.Count > 0)
                {
                    foreach (var item in ItensToListView)                                  
                    list.ItemKey = item.Key;
                    DbManager.SaveValue(list);               
                    await DialogService.DisplayAlertAsync("Lista Salva Com sucesso !", "", "Ok");
                }
            }
        }


        private void _itemClick(object obj)
        {      
            SelectItem = (Item) obj;
        }

        private async void _deleteItemDb()
        {
            if (!IsBusy) {
                IsBusy = true;
                if (SelectItem != null)
                {
                    var resp = await DialogService.DisplayAlertAsync("Remover o Item " + SelectItem.Nome + "definitivamente ?", "", "Sim", "Cancelar");
                    if (resp)
                    {
                        ItensToListView.Remove(SelectItem);
                        DbManager.DeleteItemOfList(SelectItem.Key.ToString());
                        DbManager.DeleteValueFromItem(SelectItem.Key.ToString());                       
                    }                   
                }
                else {
                    await DialogService.DisplayAlertAsync("Selecione um Item", "", "Ok");
                }
                SelectItem = null;
                IsBusy = false;
            }
        }




        private void _recoverList() {
            
            var itens = new ObservableCollection<Item>(DbManager.GetRecoverList("Lista"));
            if(itens != null) {
                ItensToListView.Clear();
                foreach (var item in itens)
                {
                    ItensToListView.Add(item);
                }
            }

        }
    }
}


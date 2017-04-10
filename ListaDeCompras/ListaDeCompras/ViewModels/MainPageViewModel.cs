using ListaDeCompras.Storage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        public ObservableCollection<Item> ItensToListView { get; set; }
        public ICommand AddItem { get; private set; }
        public ICommand SaveList { get; private set; }
        public ICommand DeleteItem { get; set; }
        private Item _selectedItem;
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
            
        }

        private string _pathImage;
        public string PathImage
        {
            get { return _pathImage; }
            set { SetProperty(ref _pathImage, value); }
        }


        public MainPageViewModel(INavigationService navigationService, 
                                IPageDialogService dialogService)
        {
            PathImage = "delete.png";
            IsBusy = false;
            ItensToListView = new ObservableCollection<Item>();
            LoadList();
            DbManager = new DatabaseManager();
            this.navigationService = navigationService;
            this.DialogService = dialogService;
            AddItem = new Command((object ItemToAdd) => _addItem(ItemToAdd));
            DeleteItem = new Command(() => _deleteItem());

                  
            MessagingCenter.Subscribe<MainPage, object>(this, "changeImage", (sender, obj) =>
            {
                _ChangeImage(obj);
            });
        }


        private void LoadList()
        {
            loadedItens = ItemService.LoadItens();
            foreach (var item in loadedItens.ItensList)
                ItensToListView.Add(item);
        }


        private async void _addItem(object itemToAdd)
        {        
            await navigationService.NavigateAsync("EditionPage");
            MessagingCenter.Send(this, "ItensToListView", ItensToListView);                        
        }


        private void _ChangeImage(object obj) {
    
            ((Image)obj).Source = "itemAdded.png";           
        }


        private async void _deleteItem()
        {

            if (SelectedItem != null) {               
                SelectedItem = null;
                var resp = await DialogService.DisplayAlertAsync("Apagar Item", "Tem certeza que deseja apagar o item " + 
                                                                  SelectedItem.Nome + " da lista ?", "Sim", "Cancelar");
                if (resp)
                {
                    ItensToListView.Remove(SelectedItem);
                    DbManager.DeleteValue(SelectedItem);                    
                }
            }
        }
    }
}



//private async void _clearLIst()
//{
//    if (!IsBusy) {
//        IsBusy = true;          
//            var resp = await DialogService.DisplayAlertAsync(
//                "Limpar Lista", "Tem certeza que deseja LIMPAR todos os itens armazenados ?", "Sim", "Cancelar");
//            if (resp)
//            {
//            DbManager.DeleteAll();
//            ItensToListView.Clear();
//            }                                                                            
//        IsBusy = false;
//    }
//}
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;


namespace ListaDeCompras
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService navigationService { get; set; }
        private IPageDialogService DialogService { get; set; }
        private NavigationParameters navigationParameters;
        public ObservableCollection<Item> ItensToListView { get; set; }  
        public DelegateCommand AddItem { get; private set; }
        public ICommand ImageClick { get; private set; }
        

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.DialogService = dialogService;
            AddItem = new DelegateCommand(() => _addItem());
            ItensToListView = new ObservableCollection<Item>();
            LoadList();
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

            ItemDirectory loadedItens = ItemService.LoadItens();
            if (loadedItens != null)
            {
                foreach (var item in loadedItens.itens)
                    ItensToListView.Add(item);
            }
        }


        private async void _addItem() {
            navigationParameters = new NavigationParameters();
            navigationParameters.Add("ItensToListView", ItensToListView);   
            await navigationService.NavigateAsync("EditionPage", navigationParameters);
        }

   
    }
}

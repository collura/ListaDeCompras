using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
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
        private NavigationParameters navigationParameters;
        public ObservableCollection<Item> ItensToListView { get; set; }  
        public ICommand AddItem { get; private set; }


        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            AddItem = new Command(() => _addItem());
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
            foreach (var item in loadedItens.itens)
                ItensToListView.Add(item);
        }


        private async void _addItem() {
            navigationParameters = new NavigationParameters();
            navigationParameters.Add("ItensToListView", ItensToListView);   
            await navigationService.NavigateAsync("EditionPage", navigationParameters);
        }
    }
}

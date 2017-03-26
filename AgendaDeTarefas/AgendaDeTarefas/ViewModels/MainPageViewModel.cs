using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace ListaDeCompras
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService NavigationService { get; set; }
        private IPageDialogService DialogService { get; set; }
        private NavigationParameters navigationParameters { get; set; }
        public ObservableCollection<Item> ItensToListView { get; set; }  
        public ICommand AddItem {get; private set; }


        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            NavigationService = navigationService;
            DialogService = dialogService;
            AddItem = new Command(_addItem);
            ItensToListView = new ObservableCollection<Item>();
            LoadList();           
        }

        void SelectedItem_Click(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Item)e.SelectedItem;
            DialogService.DisplayAlertAsync("", item.Nome, "ok");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("ItensToListView")) {
                ItensToListView = (ObservableCollection<Item>)parameters["ItensToListView"];
            }
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
            await NavigationService.NavigateAsync("EditionPage", navigationParameters);
        }       
    }
}

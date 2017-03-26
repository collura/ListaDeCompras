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
    public class EditionPageViewModel : BindableBase, INavigationAware
    {
        public ICommand SaveItem { get; set; }
        private NavigationParameters parameters {get; set;}
        private INavigationService navigation { get; set; }
        private Item item { get; set; }

        private string _descricao;
        public string Descricao {
            get { return _descricao;}
            set { SetProperty(ref _descricao, value); }
        }

        private string _quantidade;
        public string Quantidade
        {
            get { return _quantidade; }
            set { SetProperty(ref _quantidade, value); }
        }

        public EditionPageViewModel(INavigationService navigationService) {
            this.navigation = navigationService;
            SaveItem = new Command(_salvarItem);
        }

        
        private ObservableCollection<Item> collection;
        public EditionPageViewModel()
        {
            return;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            return;
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            return;
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("ItensToListView"))
            {
                collection = (ObservableCollection<Item>) parameters["ItensToListView"];
            }
        }


        public void _salvarItem() {
            item = new Item();
            parameters = new NavigationParameters();
            item.Nome = Descricao;
            item.Quantidade = Quantidade;
            collection.Add(item);
            parameters.Add("ItensToListView", collection);
            navigation.GoBackAsync(parameters);
        }
    }
}

using ListaDeCompras.Storage;
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
        private ObservableCollection<Item> collection { get; set; }
        private static DatabaseManager dbManager = new DatabaseManager();
        private INavigationService Navigation { get; set; }
        public string Nome { get; set; }
        public string Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public ICommand SalvarItem { get; set; }
    
        public EditionPageViewModel(INavigationService navigationService)
        {
            SalvarItem = new Command(_salvarItem);
            this.Navigation = navigationService;
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
                collection = (ObservableCollection<Item>)parameters["ItensToListView"];
            }
        }

        private void _salvarItem() {          
            collection.Add(new Item() { Nome = Nome, Quantidade = Quantidade, UnidadeMedida = this.UnidadeMedida });
            dbManager.SaveValue<Item>(new Item() { Nome = Nome, Quantidade = Quantidade, UnidadeMedida = this.UnidadeMedida });
            Navigation.GoBackAsync();
        }
    }
}

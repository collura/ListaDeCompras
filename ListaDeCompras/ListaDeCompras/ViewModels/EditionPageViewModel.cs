using ListaDeCompras.Storage;
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
    public class EditionPageViewModel : BindableBase
    {
        private IPageDialogService Dialog { get; set; }
        private ObservableCollection<Item> collection { get; set; }
        private static DatabaseManager dbManager = new DatabaseManager();
        private INavigationService Navigation { get; set; }
        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { SetProperty(ref _nome, value); }
        }
        public string Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public ICommand SalvarItem { get; set; }

        public EditionPageViewModel(INavigationService navigationService, 
                                    IPageDialogService dialog)
        {
            Dialog = dialog;
            SalvarItem = new Command(_salvarItem);
            this.Navigation = navigationService;

            MessagingCenter.Subscribe<MainPageViewModel, 
            ObservableCollection<Item>>(this, "teste", (sender, args) =>
            {
                collection = args;
            });
        }

        private void _salvarItem()
        {
            if (Nome == null || Quantidade == null || UnidadeMedida == null)
            {
                Dialog.DisplayAlertAsync("", "Preencha todos os campos !", "Ok");
            }
            else
            {
                Item item = new Item();
                item.Nome = Nome;
                item.Quantidade = Quantidade;
                item.UnidadeMedida = UnidadeMedida;
                dbManager.SaveValue(item);
                collection.Add(item);
                Dialog.DisplayAlertAsync(Nome + " foi Adicionado à lista !", null, "Ok");
                Navigation.GoBackAsync();
            }
        }
    }
}
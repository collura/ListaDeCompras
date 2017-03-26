using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using Prism.Services;
using System.Collections.ObjectModel;

namespace ListaDeCompras
{
    public partial class MainPage : ContentPage
    {

        private IPageDialogService dialogService;
        private ObservableCollection<Item> lista { get; set; }
        private Item selectedItem;
        private ListView ListViewSender;
        public MainPage(IPageDialogService dialogService)
        {
            InitializeComponent();
            lvLista.ItemSelected += lvLista_ItemSelected;
            
            lista = (ObservableCollection<Item>)lvLista.ItemsSource;
            //lvLista.GestureRecognizers = new GestureRecognizer();
            this.dialogService = dialogService;
        }
        
        private void lvLista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedItem = (Item) e.SelectedItem;
            ListViewSender = (ListView)sender;            
        }

                public void ItemFinished() {
            ItemService.DeleteItem(lista, selectedItem);
        }
    }      
}


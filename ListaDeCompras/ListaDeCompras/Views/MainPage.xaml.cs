using ListaDeCompras.Storage;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDeCompras
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Item> itens { get; set; }
        private bool IsBusy { get; set; }
        private static DatabaseManager dbManager = new DatabaseManager();


        public MainPage()
        {
            InitializeComponent();
            lvLista.ItemSelected += lvLista_ItemSelected;
            itens = (ObservableCollection <Item>) lvLista.ItemsSource;
            IsBusy = false;                    
        }

        private async void lvLista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            if (!IsBusy)
            {
                IsBusy = true;
                var resp = await DisplayAlert("Eliminar Item ?", null, "Sim", "Cancelar");
                if (resp)
                {
                    itens.Remove((Item)e.SelectedItem);
                    dbManager.DeleteValue<Item>((Item)e.SelectedItem);
                }
                ((ListView)sender).SelectedItem = null;
                IsBusy = false;
            }                    
        }
    }
}

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

        public MainPage()
        {
            InitializeComponent();
            lvLista.ItemSelected += lvLista_ItemSelected;
            itens = (ObservableCollection <Item>) lvLista.ItemsSource;
            IsBusy = false;                    
        }

        private async void lvLista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            if (!IsBusy)
            {
                IsBusy = true;
                var resp = await DisplayAlert("Eliminar Item", "Item no Carrinho ?", "Sim", "Cancelar");
                if (resp)
                {
                    itens.Remove((Item)e.SelectedItem);
                }
                IsBusy = false;
            }                    
        }
    }
}

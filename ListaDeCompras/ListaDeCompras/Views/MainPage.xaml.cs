using ListaDeCompras.Storage;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDeCompras
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
           // lv.ItemSelected += _onItemSelected;                       
        }

        //private void _onItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}

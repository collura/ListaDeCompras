using ListaDeCompras.Storage;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDeCompras
{
    public partial class MainPage : ContentPage
    {

        DatabaseManager m = new DatabaseManager();

        public MainPage()
        {
            InitializeComponent();
            lv.ItemSelected += lv_ItemSelect;
        }

        private void lv_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            ListView l = (ListView)sender;
            l.SelectedItem = null;
        }


        public void ImageClick() {
            MessagingCenter.Send(this, "changeImage");                       
        }
    }
}

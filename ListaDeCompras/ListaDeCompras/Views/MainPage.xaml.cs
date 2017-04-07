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
            Item item = (Item)e.SelectedItem;
            ListView l = (ListView) sender;
            MessagingCenter.Send(this, "getSelectedItem", item);            
        }


        public void ImageClick(object obj) {
            MessagingCenter.Send(this, "changeImage", obj);                       
        }      
    }
}

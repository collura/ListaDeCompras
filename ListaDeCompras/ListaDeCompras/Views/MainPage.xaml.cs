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
        }


        public void ImageClick(object obj) {
            MessagingCenter.Send(this, "changeImage", obj);                       
        }

        public async void ImageClick2(object obj)
        {
            try
            {                      
                 await DisplayAlert("", obj.ToString(), "Ok");              
            }
            catch (Exception e) {
                await DisplayAlert("", "Erro: " + e.Message, "Ok");
            }
        }
    }
}

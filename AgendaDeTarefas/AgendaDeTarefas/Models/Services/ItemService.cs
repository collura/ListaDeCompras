using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaDeCompras
{
    public class ItemService
    {
        private static ItemDirectory itemDirectory = new ItemDirectory();

        public static ItemDirectory LoadItens() {            
                itemDirectory.itens.Add(new Item() { Nome = "Sabonete", Quantidade = "4" });
                itemDirectory.itens.Add(new Item() { Nome = "Frios", Quantidade = "900" });
                itemDirectory.itens.Add(new Item() { Nome = "Gatorade", Quantidade = "5" });
                itemDirectory.itens.Add(new Item() { Nome = "Atum", Quantidade = "7" });

           return itemDirectory;
        }


        public static void DeleteItem(ObservableCollection<Item> lista, Item item){
            lista.Remove(item);
        }
    }
}

using ListaDeCompras.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompras
{
    public class ItemService
    {
        private static DatabaseManager dbManager = new DatabaseManager();
       
        public static ItemDirectory LoadItens() {
            ItemDirectory itemDirectory = new ItemDirectory();
            itemDirectory.itens = new ObservableCollection<Item>(dbManager.GetAllItems<Item>());
            return itemDirectory;       
        }
    }
}

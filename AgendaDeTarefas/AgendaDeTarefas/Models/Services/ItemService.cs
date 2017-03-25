using AgendaDeTarefas.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas.Models.Services
{
    public class ItemService
    {
       
        public static ItemDirectory LoadItens() {
            ItemDirectory itemDirectory = new ItemDirectory();

                itemDirectory.itens.Add(new Item() { Nome = "Sabonete", Quantidade = 4 });
                itemDirectory.itens.Add(new Item() { Nome = "Frios", Quantidade = 900 });
                itemDirectory.itens.Add(new Item() { Nome = "Gatorade", Quantidade = 5 });
                itemDirectory.itens.Add(new Item() { Nome = "Atum", Quantidade = 7 });

            return itemDirectory;
        }
    }
}

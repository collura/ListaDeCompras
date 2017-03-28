using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompras
{
    public class ItemService
    {
       
        public static ItemDirectory LoadItens() {
            ItemDirectory itemDirectory = new ItemDirectory();

                itemDirectory.itens.Add(new Item() { Nome = "Sabonete", Quantidade = "4", UnidadeMedida="Unidades"});
                itemDirectory.itens.Add(new Item() { Nome = "Frios", Quantidade = "9", UnidadeMedida = "Gramas" });
                itemDirectory.itens.Add(new Item() { Nome = "Gatorade", Quantidade = "5", UnidadeMedida = "Unidades" });
                itemDirectory.itens.Add(new Item() { Nome = "Atum", Quantidade = "10", UnidadeMedida = "Unidades" });
                itemDirectory.itens.Add(new Item() { Nome = "Pasta de Dente", Quantidade = "2", UnidadeMedida = "Unidades" });
                itemDirectory.itens.Add(new Item() { Nome = "Escova de Dente", Quantidade = "2", UnidadeMedida = "Unidades" });
                itemDirectory.itens.Add(new Item() { Nome = "Refrigerante", Quantidade = "8", UnidadeMedida = "Litros" });
                itemDirectory.itens.Add(new Item() { Nome = "Alface", Quantidade = "2", UnidadeMedida = "Unidades" });
            return itemDirectory;
        }
    }
}

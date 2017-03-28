using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeTarefas
{
    public class Item
    {
        private string _nome;
        public string Nome {
            get { return _nome; }
            set { _nome = value; }
        }

       

        private int _quantidade;
        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }



        private int _preco;
        public int Preco
        {
            get { return _preco; }
            set { _preco = value; }
        }
    }
}

using ListaDeCompras.Storage;
using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompras
{
    class ListItems : BindableBase, IKeyObject
    {


        private int _itemKey;
        public int ItemKey {
            get { return _itemKey; }
            set { SetProperty(ref _itemKey, value); }

        }


        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }



        [PrimaryKey, AutoIncrement]
        public int Key
        {
            get;
            set;
            }
        }
    }


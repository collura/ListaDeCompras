using ListaDeCompras.Storage;
using System.Collections.ObjectModel;
using System;
using Prism.Mvvm;
using SQLite;

namespace ListaDeCompras
{
    public class ItemDirectory : BindableBase, IKeyObject
    {
        private ObservableCollection<Item> _itensList;
        public ObservableCollection<Item> ItensList
        {
            get { return _itensList; }
            set { SetProperty(ref _itensList, value); }
        }


        [PrimaryKey, AutoIncrement]
        public int Key
        {
            get;
            set;
        }
    }
}

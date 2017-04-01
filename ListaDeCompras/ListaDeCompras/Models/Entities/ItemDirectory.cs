using ListaDeCompras.Storage;
using System.Collections.ObjectModel;
using System;
using Prism.Mvvm;

namespace ListaDeCompras
{
    public class ItemDirectory : BindableBase
    {
        private ObservableCollection<Item> _itensList;
        public ObservableCollection<Item> ItensList {
            get { return _itensList; }
            set{ SetProperty(ref _itensList, value); }
         }
      
    }
}

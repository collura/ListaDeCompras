﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompras
{
    public class ItemDirectory
    {
        public ObservableCollection<Item> itens { get; set; } = new ObservableCollection<Item>();
    }
}
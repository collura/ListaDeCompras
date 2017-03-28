﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeCompras
{
    public class Item : BindableBase
    {
        private string _nome;
        public string Nome {
            get { return _nome; }
            set {SetProperty(ref _nome, value); }
        }

       
        private string _quantidade;
        public string Quantidade
        {
            get { return _quantidade; }
            set { SetProperty(ref _quantidade, value); }
        }


        private string _unidadeMedida;
        public string UnidadeMedida
        {
            get { return _unidadeMedida; }
            set { SetProperty(ref _unidadeMedida, value); }
        }



        private double _preco;
        public double Preco
        {
            get { return _preco; }
            set { SetProperty(ref _preco, value); }
        }
    }
}

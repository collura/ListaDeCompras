﻿using ListaDeCompras.Storage;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListaDeCompras
{
    public class MainPageViewModel : BindableBase
    {
        private INavigationService navigationService { get; set; }        
        private bool IsBusy { get; set; }
        private ItemDirectory loadedItens { get; set; }
        private DatabaseManager DbManager { get; set; }
        private IPageDialogService DialogService { get; set; }
        private NavigationParameters navigationParameters;
        public ObservableCollection<Item> ItensToListView { get; set; }
        public ICommand AddItem { get; private set; }
        public ICommand SaveList { get; private set; }
        public ICommand ClearList { get; set; }
        private Item _selectItem;
        public Item SelectItem
        {
            get { return _selectItem; }
            set { SetProperty(ref _selectItem, value); }
            
        }

        private Image _pathImage;
        public Image PathImage
        {
            get { return _pathImage; }
            set { SetProperty(ref _pathImage, value); }
        }


        public MainPageViewModel(INavigationService navigationService, 
                                IPageDialogService dialogService)
        {
            IsBusy = false;
            ItensToListView = new ObservableCollection<Item>();
            LoadList();
            DbManager = new DatabaseManager();
            this.navigationService = navigationService;
            this.DialogService = dialogService;
            AddItem = new Command(() => _addItem());
            ClearList = new Command(() => _clearLIst());

            MessagingCenter.Subscribe<MainPage>(this, "changeImage", (sender) => {                   
                _ChangeImage();
            });            
        }


        private void LoadList()
        {
            loadedItens = ItemService.LoadItens();
            foreach (var item in loadedItens.ItensList)
                ItensToListView.Add(item);
        }


        private async void _addItem()
        {

            navigationParameters = new NavigationParameters();
            navigationParameters.Add("ItensToListView", ItensToListView);
            await navigationService.NavigateAsync("EditionPage", navigationParameters);
            MessagingCenter.Send(this, "teste", ItensToListView);
            Debug.WriteLine("Debug", "TEste de Debug");


        }


        private async void _clearLIst()
        {
            if (!IsBusy) {
                IsBusy = true;          
                    var resp = await DialogService.DisplayAlertAsync(
                        "Limpar Lista ?", "", "Sim", "Cancelar");
                    if (resp)
                    {
                    DbManager.DeleteAll();
                    ItensToListView.Clear();
                    }                                                                            
                IsBusy = false;
            }
        }


        private void _ChangeImage() {
            PathImage.Source = "delete.png";
        }
    }
}


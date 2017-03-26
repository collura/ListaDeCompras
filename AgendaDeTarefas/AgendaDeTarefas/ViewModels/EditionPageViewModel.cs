using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AgendaDeTarefas
{
    public class EditionPageViewModel : BindableBase, INavigationAware
    {

        private ObservableCollection<Item> collection;
        public EditionPageViewModel()
        {
            return;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            return;
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            return;
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("ItensToListView"))
            {
                collection = (ObservableCollection<Item>)parameters["ItensToListView"];
            }
        }
    }
}

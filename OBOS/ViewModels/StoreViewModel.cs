using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Stores;
using System.Windows.Input;
using OBOS.Commands;

namespace OBOS.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        private string _search;

        public string Search 
        { 
            get 
            { 
                return _search;
            } 
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            } 
        }

        public ICommand ToLogin { get; }
        public ICommand ToHistory { get; }
        public ICommand ToCart { get; }

        public StoreViewModel(NavigationStore navigationStore)
        {
            ToLogin=new ToLogin(navigationStore);
        }
    }
}

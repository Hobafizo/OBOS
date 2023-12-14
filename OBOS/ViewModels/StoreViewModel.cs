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
        private readonly NavigationStore _storeNavigationStore;
        public ViewModelBase CurrentViewModel => _storeNavigationStore.CurrentViewModel;

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
                SearchCommand.Execute(Search);
            } 
        }

        public ICommand ToLogin { get; }
        public ICommand ToHistory { get; }
        public ICommand ToCart { get; }
        public ICommand ToHome { get; }
        public ICommand SearchCommand { get; }

        public StoreViewModel(NavigationStore navigationStore)
        {
            _storeNavigationStore = new NavigationStore();
            _storeNavigationStore.CurrentViewModel = new HomeViewModel(_storeNavigationStore);

            _storeNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            ToLogin = new ToLogin(navigationStore);
            ToHistory = new ToHistory(_storeNavigationStore);
            ToCart = new ToCart(_storeNavigationStore);
            SearchCommand = new SearchCommand(_storeNavigationStore);
            ToHome = new ToHome(_storeNavigationStore);
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

    }
}

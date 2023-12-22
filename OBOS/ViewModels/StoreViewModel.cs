using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Stores;
using System.Windows.Input;
using OBOS.Commands;
using OBOS.Models.Store;

namespace OBOS.ViewModels
{
    public class StoreViewModel : ViewModelBase
    {
        private readonly NavigationStore _storeNavigationStore;
        public ViewModelBase StoreCurrentViewModel => _storeNavigationStore.CurrentViewModel;

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
                SearchCommand.Execute(Search, Filters);
            } 
        }

        private string _username;
        public string UserName
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public List<Category> Categories { get; }

        private List<string> _filters;
        public List<string> Filters
        {
            get => _filters;
            set
            {
                _filters = value;
                OnPropertyChanged(nameof(Filters));
                SearchCommand.Execute(Search, Filters);
            }
        }

        public ICommand ToLogin { get; }
        public ICommand ToHistory { get; }
        public ICommand ToCart { get; }
        public ICommand ToHome { get; }
        public SearchCommand SearchCommand { get; }

        public StoreViewModel(NavigationStore navigationStore,string username)
        {
            _storeNavigationStore = new NavigationStore();
            _storeNavigationStore.CurrentViewModel = new HomeViewModel(_storeNavigationStore);

            _storeNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            ToLogin = new ToLogin(navigationStore);
            ToHistory = new ToHistory(_storeNavigationStore);
            ToCart = new ToCart(_storeNavigationStore);
            SearchCommand = new SearchCommand(_storeNavigationStore);
            ToHome = new ToHome(_storeNavigationStore);

            UserName = username;

            Categories = Shop.GetInstance().Categories;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(StoreCurrentViewModel));
        }

    }
}

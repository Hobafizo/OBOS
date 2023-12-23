using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OBOS.Stores;
using OBOS.Commands;
using OBOS.Models.Users;
using OBOS.Models.Store;

namespace OBOS.ViewModels
{
	public class AdminViewModel : ViewModelBase
	{
		private readonly NavigationStore _adminNavigationStore;
		public ViewModelBase CurrentViewModel => _adminNavigationStore.CurrentViewModel;

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

        public ICommand ToLogin { get; }

		public AdminViewModel(NavigationStore navigationStore, string username)
		{
			_adminNavigationStore = new NavigationStore();
			_adminNavigationStore.CurrentViewModel = new MainAdminViewModel(_adminNavigationStore);
			_adminNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            ToLogin = new ToLogin(navigationStore);

            UserName = username;
        }

		private void OnCurrentViewModelChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
		}
    }
}

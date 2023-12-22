﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Stores;
using System.Windows.Input;
using OBOS.Commands;

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
		public ICommand ToHistory { get; }
		public ICommand ToCart { get; }
		public ICommand ToHome { get; }
		public ICommand SearchCommand { get; }

		public AdminViewModel(NavigationStore navigationStore, string username)
		{
			_adminNavigationStore = new NavigationStore();
			_adminNavigationStore.CurrentViewModel = new HomeViewModel(_adminNavigationStore);
			_adminNavigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

			ToLogin = new ToLogin(navigationStore);
			ToHistory = new ToHistory(_adminNavigationStore);
			ToCart = new ToCart(_adminNavigationStore);
			SearchCommand = new SearchCommand(_adminNavigationStore);
			ToHome = new ToHome(_adminNavigationStore);

			UserName = username;
		}

		private void OnCurrentViewModelChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
		}

	}
}

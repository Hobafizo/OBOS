using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using OBOS.ViewModels;
using OBOS.Stores;
using OBOS.Models.Store;
using OBOS.Models.Users;

namespace OBOS.Commands
{
	public class LoginCommand : CommandBase
	{
		private readonly LoginViewModel loginViewModel;
		private readonly Shop shop;
		private ICommand ToStore { get; }
		private ICommand ToAdmin { get; }

		public LoginCommand(LoginViewModel viewModel, NavigationStore navigationStore)
		{
			loginViewModel = viewModel;
			shop = Shop.GetInstance();
			ToStore = new ToStore(navigationStore);
			ToAdmin = new ToAdmin(navigationStore);
			loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
		}

		private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(LoginViewModel.Username) || e.PropertyName==nameof(LoginViewModel.Password))
			{
				OnCanExecuteChanged();
			}
		}

		public override void Execute(object parameter)
		{
			User user = Login(loginViewModel.Username, loginViewModel.Password);
			ICommand cmd = user.GetType() == typeof(Admin) ? ToAdmin : ToStore;
			cmd.Execute(user.UserName);
		}

		public override bool CanExecute(object parameter)
		{
			return !string.IsNullOrEmpty(loginViewModel.Username) &&
				!string.IsNullOrEmpty(loginViewModel.Password) && 
				base.CanExecute(parameter);
		}

		public User Login(string username, string pw)
		{
			foreach (var user in shop.Users)
			{

				if (username == user.UserName && user.Password == pw)
				{
					shop.CurrentUser = user;
					return user;
				}
			}
			return null;
		}

	}
}

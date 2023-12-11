using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.ViewModels;
using OBOS.Models.Store;
using System.Windows.Input;
using OBOS.Stores;
using System.ComponentModel;

namespace OBOS.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel loginViewModel;
        private readonly Shop shop;
        private ICommand ToStore { get; }

        public LoginCommand(LoginViewModel viewModel, NavigationStore navigationStore)
        {
            loginViewModel = viewModel;
            shop = Shop.GetInstance();
            ToStore = new ToStore(navigationStore);
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
            if (Login(loginViewModel.Username, loginViewModel.Password))
                ToStore.Execute(null);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(loginViewModel.Username) &&
                !string.IsNullOrEmpty(loginViewModel.Password) && 
                base.CanExecute(parameter);
        }

        public bool Login(string username, string pw)
        {
            foreach (var user in shop.Users)
            {

                if (username == user.UserName && user.Password == pw)
                {
                    shop.CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

    }
}

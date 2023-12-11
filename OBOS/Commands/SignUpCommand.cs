using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.ViewModels;
using OBOS.Stores;
using System.ComponentModel;
using OBOS.Models.Store;
using OBOS.Models.Users;

namespace OBOS.Commands
{
    public class SignUpCommand : CommandBase
    {
        private readonly SignUpViewModel _viewModel;
        private readonly Shop shop;
        private ToLogin ToLogin { get; }

        public SignUpCommand(SignUpViewModel viewModel, NavigationStore navigationStore)
        {
            _viewModel = viewModel;
            shop = Shop.GetInstance();
            ToLogin = new ToLogin(navigationStore);
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }


        public override void Execute(object parameter)
        {
            if (Register(_viewModel.Username, _viewModel.Password, _viewModel.Address, _viewModel.Phone))
                ToLogin.Execute(parameter);
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Username) &&
                !string.IsNullOrEmpty(_viewModel.Phone) &&
                !string.IsNullOrEmpty(_viewModel.Address) &&
                (!string.IsNullOrEmpty(_viewModel.Password) &&
                !string.IsNullOrEmpty(_viewModel.Confirm) &&
                _viewModel.Password == _viewModel.Confirm)
                && base.CanExecute(parameter);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SignUpViewModel.Username) ||
                e.PropertyName == nameof(SignUpViewModel.Phone) ||
                e.PropertyName == nameof(SignUpViewModel.Address) ||
                e.PropertyName == nameof(SignUpViewModel.Password) ||
                e.PropertyName == nameof(SignUpViewModel.Confirm))
                OnCanExecuteChanged();
        }

        public bool Register(string username, string pw, string address, string phone)
        {
            bool isadmin = false;
            foreach (var user1 in shop.Users)
            {
                if (username == user1.UserName)
                {
                    return false;

                }
            }

            if(username.EndsWith("@admin"))
            {
                isadmin = true;
                username = username.Replace("@admin", "");
            }

            User user;
            if (isadmin == true)
                user = new Admin(User.IdCounter, username, pw, phone, address);
            else
                user = new Customer(User.IdCounter, username, pw, phone, address);

            Shop.GetInstance().Users.Add(user);
            shop.CurrentUser = user;
            User.IdCounter++;
            return true;
        }


    }
}

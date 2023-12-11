using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OBOS.Commands;
using OBOS.Stores;

namespace OBOS.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _phone;
        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _confirm;
        public string Confirm
        {
            get => _confirm;
            set
            {
                _confirm = value;
                OnPropertyChanged(nameof(Confirm));
            }
        }

        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public ICommand ToLogin { get; }
        public ICommand SignUpCommand { get; }
        public SignUpViewModel(NavigationStore navigationStore)
        {
            ToLogin = new ToLogin(navigationStore);
            SignUpCommand = new SignUpCommand();
        }
    }
}

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
    public class LoginViewModel : ViewModelBase
    {

        private string _username;
        public string Username 
        {
            get
            { 
                return _username;
            }
            set 
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            } 
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand ToSignUp { get; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            ToSignUp = new ToSignUp(navigationStore);
            LoginCommand = new LoginCommand(this,navigationStore);

        }
    }
}

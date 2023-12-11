using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.ViewModels;
using OBOS.Models.Store;

namespace OBOS.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel loginViewModel;
        private readonly Shop shop;

        public LoginCommand(LoginViewModel viewModel)
        {
            loginViewModel = viewModel;
            shop = Shop.GetInstance();
        }

        public override void Execute(object parameter)
        {
            
        }

    }
}

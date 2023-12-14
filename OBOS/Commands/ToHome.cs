using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Stores;
using OBOS.ViewModels;

namespace OBOS.Commands
{
    public class ToHome : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public ToHome(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
        }
    }
}

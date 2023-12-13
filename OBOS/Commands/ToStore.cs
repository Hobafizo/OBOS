using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Stores;
using OBOS.ViewModels;

namespace OBOS.Commands
{
    public class ToStore : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public ToStore(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new StoreViewModel(_navigationStore);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Stores;
using OBOS.ViewModels;

namespace OBOS.Commands
{
    public class ToHistory : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public ToHistory(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            if (_navigationStore.CurrentViewModel is HistoryViewModel) { }

            else
                _navigationStore.CurrentViewModel = new HistoryViewModel(_navigationStore);
        }
    }
}

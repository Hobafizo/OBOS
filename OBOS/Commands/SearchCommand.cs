using OBOS.Models.Store;
using OBOS.Stores;
using OBOS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Commands
{
    public class SearchCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        List<Book> Result;
        Shop Shop;

        public SearchCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            Shop=Shop.GetInstance();
            Result=new List<Book>();
        }

        public override void Execute(object parameter)
        {
            if ((string)parameter == "")
                _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
            else
            {

                Result = Shop.Books.Where(c => c.Name.Contains((string)parameter)).ToList();
                _navigationStore.CurrentViewModel = new SearchViewModel(Result,_navigationStore);
            }
        }
    }
}

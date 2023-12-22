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
            
        }

        public void Execute(object parameter1, object parameter2)
        {
            if (string.IsNullOrEmpty((string)parameter1) && ((List<string>)parameter2 == null || ((List<string>)parameter2).Count == 0))
            {
                _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore);
                return;
            }
            else if (string.IsNullOrEmpty((string)parameter1))
            {
                if (((List<string>)parameter2).Count == 1 && ((List<string>)parameter2)[0] == "All")
                {
                    Result = Shop.Books;
                }
                else
                {
                    foreach (var item in (List<string>)parameter2)
                    {
                        Result = Shop.Books.Where(x => x.CategoryNames.Contains(item)).ToList();
                    }
                }

            }
            else if ((List<string>)parameter2 == null || ((List<string>)parameter2).Count == 0)
            {
                Result = Shop.Books.Where(c => c.Name.Contains((string)parameter1)).ToList();
            }
            else
            {
                foreach (var item in (List<string>)parameter2)
                {
                    Result = Shop.Books.Where(x => x.CategoryNames.Contains(item) && x.Name == (string)parameter1).ToList();
                }
            }

            _navigationStore.CurrentViewModel = new SearchViewModel(Result, _navigationStore);
        }
    }
}

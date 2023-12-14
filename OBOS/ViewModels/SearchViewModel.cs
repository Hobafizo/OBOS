using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Store;
using OBOS.Stores;

namespace OBOS.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        public List<Book> SearchResult { get; }


        public SearchViewModel(List<Book> result,NavigationStore navigationStore)
        {
            SearchResult = result.ToList();
        }
    }
}

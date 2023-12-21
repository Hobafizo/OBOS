using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Store;
using OBOS.Stores;

namespace OBOS.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public List<Book> TopSellers;

        public List<Book> Latest;

        private readonly Shop shop;

        public HomeViewModel(NavigationStore navigationStore)
        {
            shop = Shop.GetInstance();
            //TopSellers = shop.DisplayTopSellers().ToList();
            Latest = shop.DisplayLatest().ToList();
        }
    }
}
    

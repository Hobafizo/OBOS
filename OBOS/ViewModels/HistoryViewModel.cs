using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Payments;
using OBOS.Models.Store;
using OBOS.Models.Users;
using OBOS.Stores;

namespace OBOS.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        public List<Order> OrderHistory => ((Customer)Shop.GetInstance().CurrentUser).OrderHistory;
        
        public HistoryViewModel(NavigationStore navigationStore)
        {

        }
    }
}

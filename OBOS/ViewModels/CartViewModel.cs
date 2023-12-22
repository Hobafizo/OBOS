using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OBOS.Commands;
using OBOS.Models.Store;
using OBOS.Models.Users;
using OBOS.Stores;

namespace OBOS.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        public ICommand PlaceOrder { get; }

        public List<CartItem> Cart;

        public CartViewModel(NavigationStore navigationStore)
        {
            PlaceOrder = new PlaceOrderCommand();
            Cart = ((Customer)Shop.GetInstance().CurrentUser).Cart;
        }
    }
}

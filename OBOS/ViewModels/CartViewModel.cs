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

        public List<CartItem> Cart { get; set; }

        public float Total { get; }

        public CartViewModel(NavigationStore navigationStore)
        {
            Cart = ((Customer)Shop.GetInstance().CurrentUser).Cart;
            Total = ((Customer)Shop.GetInstance().CurrentUser).CartTotal();
            PlaceOrder = new PlaceOrderCommand(Cart, navigationStore);
        }
    }
}

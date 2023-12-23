using OBOS.Models.Payments;
using OBOS.Models.Store;
using OBOS.Models.Users;
using OBOS.Stores;
using OBOS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Commands
{
    public class PlaceOrderCommand : CommandBase
    {
        Shop shop => Shop.GetInstance();

        List<CartItem> Cart;

        ToHistory ToHistory;

        public PlaceOrderCommand(List<CartItem> cart,NavigationStore navigationStore)
        {
            Cart = cart;
            ToHistory = new ToHistory(navigationStore);
        }

        public override void Execute(object parameter)
        {
            Admin.Notifications.Push(new Notification() { Message = "Order confirm", Time = DateTime.Now }); 
            ((Customer)shop.CurrentUser).OrderHistory.Add(new Order(Cart)
            {   
                Date=DateTime.Now,
                Customer=(Customer)shop.CurrentUser,
                CustomerId=shop.CurrentUser.Id
            });

            ((Customer)shop.CurrentUser).Cart.Clear();

            ToHistory.Execute(null);
        }
    }
}

using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Store;
using OBOS.Models.Payments;

namespace OBOS.Models.Users
{
	public class Customer : User
	{
        // <<<< Attributes here >>>>
		private Shop shop = Shop.GetInstance();
        Stack<Notification> notifications = new Stack<Notification>();
        List<CartItem> Cart = new List<CartItem>();
		List<Order> OrderHistory = new List<Order>();

        public int AddCart(Book book, int quantity)
		{
			if (book.Stock >= quantity)
			{
				Cart.Add(new CartItem(book, quantity));	
			}						
			return Cart.Count + 1;
		}

		public void EditCart(Book book, int quantity)
		{

			foreach (var item in Cart)
			{
				if (item.Book == book && quantity >= item.Quantity)
				{
					item.Quantity = quantity;
				}

			}
						            
		}

		public void RemoveCart(List<CartItem> Cart)
		{						
				Cart.Clear();			
		}

		public void RemoveItem( CartItem cartitem)
		{

			if (Cart.Contains(cartitem))
			{
				Cart.Remove(cartitem);
			}

		}
		

		public bool PlaceOrder(IPaymentStartegy method)
		{
			foreach(var item in Cart)
			{
				item.Book.Stock -=item.Quantity;				
			}
			//shop.Users.
			return true;
		}

		public void AddReview(Book book, int rating, string message)
		{

		}
	}
}

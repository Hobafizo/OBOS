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
        Stack<Notification> notifications = new Stack<Notification>();
        List<CartItem> Cart = new List<CartItem>();
		List<Order> OrderHistory = new List<Order>();
		//List<CartItem> cartItems = new List<CartItem>();

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

		public bool RemoveCart(List<CartItem> Cartitems)
		{
			if (Cartitems.Count < 0 )
			{
				return false;

			}
			foreach (var item in Cartitems)
			{
			Cartitems.Remove(item);
			} 
			return true;
		}

		public bool PlaceOrder(IPaymentStartegy method)
		{
			return false;
		}

		public void AddReview(Book book, int rating, string message)
		{

		}
	}
}

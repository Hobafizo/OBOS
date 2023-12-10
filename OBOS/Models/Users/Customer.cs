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


        public int AddCart(Book book, int quantity)
		{
			if (book.Stock >= quantity)
			{
				//book.Quantity = quantity;
				Cart.Add(new CartItem(book, quantity));	
			}
			book.Stock -= quantity;				
			return Cart.Count - 1;
		}

		public void EditCart(int cartindex, int quantity)
		{
			
                if (cartindex >= 0 && cartindex < Cart.Capacity )
                {
					//Cart[cartindex].Quantity = quantity;
                }
						
            
		}

		public void RemoveCart(int cartindex)
		{
			
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

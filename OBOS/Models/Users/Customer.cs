using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Payments;

using System.Windows.Documents;

namespace OBOS.Models.Users
{
	public class Customer : User
	{
        // <<<< Attributes here >>>>
        Stack<Notification> notifications = new Stack<Notification>();
		List<Book> Cart = new List<Book>();
		List<Order> OrderHistory = new List<Order>();


        public int AddCart(Book book, int quantity)
		{
			if (book.Stock >= quantity)
			{
				//book.Quantity = quantity;
				Cart.Add(book);	
			}
			book.Stock -= quantity;				
			return Cart.IndexOf(book);
		}

		public void EditCart(int cartindex, int quantity)
		{
			
                if (cartindex >= 0 && cartindex < Cart.Capacity )
                {
					Cart[cartindex].Quantity = quantity;
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

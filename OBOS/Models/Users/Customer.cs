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
        Stack<Notification> Notifications = new Stack<Notification>();
        List<CartItem> Cart = new List<CartItem>();
		List<Order> OrderHistory = new List<Order>();

        public int AddItem(Book book, int quantity)
		{
			if (book.Stock >= quantity)
			{
				Cart.Add(new CartItem(book, quantity));
                return Cart.Count - 1;
            }
			return -1;
		}

		public void EditItem(int cartindex, int quantity) // index of book that will be updated,
		{
            CartItem item;

			for (int i = 0; i < Cart.Count; ++i)
			{
                item = Cart[i];

				if (i == cartindex && quantity >= item.Book.Stock) 
				{
					item.Quantity = quantity;
				}

			}
						            
		}

        public void ClearCart()
        {
            Cart.Clear();
        }

		public void RemoveItem(int cartindex)
		{

			if (cartindex >= 0 && cartindex < Cart.Count)
			{
				Cart.RemoveAt(cartindex);
			}

		}
		

		public bool PlaceOrder(IPaymentStartegy method)
		{
			foreach(var item in Cart)
			{
				item.Book.Stock -=item.Quantity;

                if (item.Book.Stock == 0)
                {
                    item.Book.Status = BookStatus.OutOfStock;

                }
			}
			//shop.Users.
			return true;
		}

		public void AddReview(Book book, int rating, string message)
		{



		}

        public Customer(int Id,string Username, string Password,string Phone, string Address): base(Id,Username,Password,Address,Phone)
        {

        }

        public Customer()
        {

        }
	}
}

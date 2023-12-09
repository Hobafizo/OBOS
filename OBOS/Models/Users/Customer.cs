using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Payments;

namespace OBOS.Models.Users
{
	public class Customer : User
	{
		// <<<< Attributes here >>>>

		public int AddCart(Book book, int quantity)
		{
			return 0;
		}

		public void EditCart(int cartindex, int quantity)
		{

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

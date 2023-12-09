using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Users;
using OBOS.Models.Payments;

namespace OBOS.Models.Store
{
    public class Shop
    {
		// <<<< Attributes here >>>>
		public static Shop Instance { get; set; }
		public List<Book> Books { get; set; }
		public List<Order> Orders { get; set; }
		public List<User> Users { get; set; }
		public List<Category> Categories { get; set; }
		// Books, Orders mlhom4 getter

		private Shop()
        {
			Users = new List<User>();
			Categories = new List<Category>();
			Books = new List<Book>();
			Orders = new List<Order>();
		}

        
        public IEnumerable<Book> DisplayTopSellers()
        {
			//return Books.Where(r => r.Sales >= 12000);
		}
		

		public IEnumerable<Book> DisplayAllBooks()
		{
		 return Books;
		}

		public IEnumerable<Book> DisplayCategory(Category category)
		{
			return Books.Where(c => c.Category.equals(category));
		}

		public static Shop GetInstance()
        {
			if (Instance == null)
			{
				Instance = new Shop();

			}

			return Instance;
		}
    }
}

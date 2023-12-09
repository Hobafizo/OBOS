using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Users;

namespace OBOS.Models.Store
{
    public class Shop
    {
		// <<<< Attributes here >>>>
		public List<User> Users { get; set; }
		public List<Category> Categories { get; set; }
		// Books, Orders mlhom4 getter

		private Shop()
        {
			Users = new List<User>();
			Categories = new List<Category>();
        }

        public IEnumerable<Book> DisplayTopSellers()
        {
            return null;
        }

		public IEnumerable<Book> DisplayAllBooks()
		{
			return null;
		}

		public IEnumerable<Book> DisplayCategory(Category category)
		{
			return null;
		}

		public static Shop GetInstance()
        {
            return null;
        }
    }
}

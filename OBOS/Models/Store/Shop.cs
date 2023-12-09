using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Store
{
    public class Shop
    {
		// <<<< Attributes here >>>>
		public List<Category> Categories { get; set; }
		// Books, Orders mlhom4 getter

		private Shop()
        {
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

		public Shop GetInstance()
        {
            return null;
        }
    }
}

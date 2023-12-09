using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Users
{
	public class Admin : User
	{
		// <<<< Attributes here >>>>
		Shop shop;
        public Admin()
        {
			shop = Shop.GetInstance();

        }

        public bool AddCategory( Category category)
		{
			if (shop.Categories.Contains(category)) 
			{
				return false;
			}
			shop.Categories.Add(category);
			return true;
		}

		public bool DeleteCategory(Category category)
		{
            if (shop.Categories.Contains(category))
            { 
				shop.Categories.Remove(category);
                return true;
            }
          
            return false;
        }

		public bool AddBook(Book book)
		{
			if (shop.Books.Contains(book))
			{
				return false;
			}
			shop.Books.Add(book);
			return true;

		}

		public bool UpdateBookStatus(Book book, BookStatus status)
		{
			foreach (var item in shop.Books)
			{
				if (book == item)
				{
					book.Status = status;
					return true;	
				}
			}
			return false;	
		}
	}
}

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
		private Shop shop;
        public static Stack<Notification> Notifications = new Stack<Notification>();

        public Admin()
        {
			shop = Shop.GetInstance();

        }

        public bool AddCategory(string name)
		{
            foreach (Category category2 in shop.Categories)
            {
                if (category2.Name == name)
                {
                    return false;
                }
            }

            Category category = new Category();
            category.Name = name;
            category.CreationDate = DateTime.Now;

            shop.Categories.Add(category);
			return true;
		}

		public bool DeleteCategory(string name)
		{
            foreach (Category category in shop.Categories)
            {
                if (category.Name == name)
                {
                    shop.Categories.Remove(category);
                    return true;
                }
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

		public Admin(int Id, string Username, string Password, string Phone, string Address) : base(Id, Username, Password, Address, Phone)
		{

		}

	}
}

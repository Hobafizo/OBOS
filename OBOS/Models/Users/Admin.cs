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
        public static Stack<Notification> Notifications = new Stack<Notification>();

        public Admin()
        {

        }

        public Admin(int Id, string Username, string Password, string Phone, string Address) : base(Id, Username, Password, Address, Phone)
        {

        }

        public bool AddCategory(string name)
		{
            Shop shop = Shop.GetInstance();

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
            Shop shop = Shop.GetInstance();

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
            Shop shop = Shop.GetInstance();

            foreach (var item in shop.Books)
            {
                if (book.Name == item.Name)
                {
                    return false;
                }
            }
			shop.Books.Add(book);
			return true;

		}

		public bool UpdateBookStatus(string name, BookStatus status)
		{
            Shop shop = Shop.GetInstance();

            foreach (var item in shop.Books)
			{
				if (name == item.Name)
				{
					item.Status = status;

                    if (status == BookStatus.OutOfStock)
                        item.Stock = 0;

					return true;	
				}
			}
			return false;	
		}
	}
}

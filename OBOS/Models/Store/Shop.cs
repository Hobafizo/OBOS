	using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Users;
using OBOS.Models.Payments;
using Newtonsoft.Json;

namespace OBOS.Models.Store
{
    public class Shop
    {
		// <<<< Attributes here >>>>
		private static Shop Instance { get; set; }

        public List<User> Users { get; set; }
        public List<Category> Categories { get; set; }
        public List<Book> Books { get; set; }
		public List<Order> Orders { get; set; }

        public User CurrentUser { get; set; }
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
			return null;
		}
		

		public IEnumerable<Book> DisplayAllBooks()
		{
            return Books;
		}

		public IEnumerable<Book> DisplayCategory(Category category)
		{
            return Books.Where(c => c.Categories.Contains(category));
		}

        public IEnumerable<Book> DisplayLatest()
        {
            int count = 0;
            IEnumerable<Book> books = new List<Book>();
            for (int i = Books.Count - 1; count < 5&& i>=0; i--)
            {
                count++;
                books.ToList().Add(Books[i]);
            }
            return books;
        }

        public User GetUser(int id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }

        public Category GetCategory(string name)
        {
            return Categories.FirstOrDefault(x => x.Name == name);
        }

        public List<Category> GetCategories(List<string> names)
        {
            List<Category> categories = new List<Category>();

            foreach (Category cat in Categories)
            {
                if (names.Contains(cat.Name))
                    categories.Add(cat);
            }

            return categories;
        }

        public Book GetBook(int id)
        {
            return Books.FirstOrDefault(x => x.Id == id);
        }

        public Order GetOrder(int id)
        {
            return Orders.FirstOrDefault(x => x.Id == id);
        }

        public static void SetInstance(JsonSerializer serializer, JsonReader reader)
        {
            Instance = serializer.Deserialize<Shop>(reader);
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

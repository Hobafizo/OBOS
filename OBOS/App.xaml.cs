using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using OBOS.Stores;
using OBOS.ViewModels;
using OBOS.Models.Payments;
using OBOS.Models.Store;
using OBOS.Models.Users;
using OBOS.Database;

using Newtonsoft.Json.Linq;

namespace OBOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            OnSettings();

            _navigationStore.CurrentViewModel = new LoginViewModel(_navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);

        }

        public static Random rand = new Random(Guid.NewGuid().GetHashCode());

        private void OnSettings()
        {
            Settings.Load();
        }

        private void OnDataGeneration()
        {
            Shop shop = Shop.GetInstance();

            List<string> categories = new List<string>();

            foreach (JObject data in JArray.Parse(
                @"[
                      {
                        'Id': 1,
                        'Name': 'To Kill a Mockingbird',
                        'Author': 'Harper Lee',
                        'Price': 14.99,
                        'Stock': 50,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Classics']
                      },
                      {
                        'Id': 2,
                        'Name': '1984',
                        'Author': 'George Orwell',
                        'Price': 12.99,
                        'Stock': 30,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Dystopian']
                        },
                      {
                        'Id': 3,
                        'Name': 'The Great Gatsby',
                        'Author': 'F. Scott Fitzgerald',
                        'Price': 11.49,
                        'Stock': 45,
                        'Status': 1,
                        'CategoryNames': ['Fiction', 'Classics']
                    },
                      {
                        'Id': 4,
                        'Name': 'To the Lighthouse',
                        'Author': 'Virginia Woolf',
                        'Price': 16.99,
                        'Stock': 20,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Modernist']
                      },
                      {
                        'Id': 5,
                        'Name': 'The Catcher in the Rye',
                        'Author': 'J.D. Salinger',
                        'Price': 13.79,
                        'Stock': 60,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Coming of Age']
                      },
                      {
                        'Id': 6,
                        'Name': 'Pride and Prejudice',
                        'Author': 'Jane Austen',
                        'Price': 15.49,
                        'Stock': 25,
                        'Status': 1,
                        'CategoryNames': ['Fiction', 'Romance', 'Classics']
                      },
                      {
                        'Id': 7,
                        'Name': 'Brave New World',
                        'Author': 'Aldous Huxley',
                        'Price': 14.29,
                        'Stock': 40,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Dystopian']
                      },
                      {
                        'Id': 8,
                        'Name': 'The Hobbit',
                        'Author': 'J.R.R. Tolkien',
                        'Price': 18.99,
                        'Stock': 15,
                        'Status': 0,
                        'CategoryNames': ['Fantasy']
                      },
                      {
                        'Id': 9,
                        'Name': 'The Girl on the Train',
                        'Author': 'Paula Hawkins',
                        'Price': 12.99,
                        'Stock': 35,
                        'Status': 1,
                        'CategoryNames': ['Mystery', 'Thriller']
                      },
                      {
                        'Id': 10,
                        'Name': 'Sapiens: A Brief History of Humankind',
                        'Author': 'Yuval Noah Harari',
                        'Price': 22.49,
                        'Stock': 50,
                        'Status': 0,
                        'CategoryNames': ['Non-Fiction', 'History']
                      },
                      {
                        'Id': 11,
                        'Name': 'The Alchemist',
                        'Author': 'Paulo Coelho',
                        'Price': 11.99,
                        'Stock': 10,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Philosophical']
                      },
                      {
                        'Id': 12,
                        'Name': 'Educated',
                        'Author': 'Tara Westover',
                        'Price': 17.99,
                        'Stock': 28,
                        'Status': 0,
                        'CategoryNames': ['Biography', 'Memoir']
                      },
                      {
                        'Id': 13,
                        'Name': 'The Silent Patient',
                        'Author': 'Alex Michaelides',
                        'Price': 16.49,
                        'Stock': 18,
                        'Status': 1,
                        'CategoryNames': ['Mystery', 'Thriller']
                      },
                      {
                        'Id': 14,
                        'Name': 'The Road',
                        'Author': 'Cormac McCarthy',
                        'Price': 14.99,
                        'Stock': 22,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Post-Apocalyptic']
                      },
                      {
                        'Id': 15,
                        'Name': 'The Goldfinch',
                        'Author': 'Donna Tartt',
                        'Price': 19.99,
                        'Stock': 15,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Mystery']
                      },
                      {
                        'Id': 16,
                        'Name': 'The Shining',
                        'Author': 'Stephen King',
                        'Price': 15.99,
                        'Stock': 30,
                        'Status': 0,
                        'CategoryNames': ['Horror']
                      },
                      {
                        'Id': 17,
                        'Name': 'The Handmaid Tale',
                        'Author': 'Margaret Atwood',
                        'Price': 14.49,
                        'Stock': 25,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Dystopian']
                      },
                      {
                        'Id': 18,
                        'Name': 'Lord of the Flies',
                        'Author': 'William Golding',
                        'Price': 13.29,
                        'Stock': 40,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Classics']
                      },
                      {
                        'Id': 19,
                        'Name': 'One Hundred Years of Solitude',
                        'Author': 'Gabriel Garcia Marquez',
                        'Price': 20.99,
                        'Stock': 20,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Magical Realism']
                      },
                      {
                        'Id': 20,
                        'Name': 'The Da Vinci Code',
                        'Author': 'Dan Brown',
                        'Price': 16.79,
                        'Stock': 18,
                        'Status': 1,
                        'CategoryNames': ['Mystery', 'Thriller']
                      },
                      {
                        'Id': 21,
                        'Name': 'The Hunger Games',
                        'Author': 'Suzanne Collins',
                        'Price': 14.99,
                        'Stock': 50,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Dystopian']
                      },
                      {
                        'Id': 22,
                        'Name': 'The Kite Runner',
                        'Author': 'Khaled Hosseini',
                        'Price': 12.49,
                        'Stock': 35,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Historical Fiction']
                      },
                      {
                        'Id': 23,
                        'Name': 'The Martian',
                        'Author': 'Andy Weir',
                        'Price': 17.99,
                        'Stock': 15,
                        'Status': 0,
                        'CategoryNames': ['Science Fiction']
                      },
                      {
                        'Id': 24,
                        'Name': 'The Fault in Our Stars',
                        'Author': 'John Green',
                        'Price': 11.99,
                        'Stock': 40,
                        'Status': 0,
                        'CategoryNames': ['Young Adult', 'Romance']
                      },
                      {
                        'Id': 25,
                        'Name': 'The Catcher in the Rye',
                        'Author': 'J.D. Salinger',
                        'Price': 13.79,
                        'Stock': 30,
                        'Status': 1,
                        'CategoryNames': ['Fiction', 'Coming of Age']
                      },
                      {
                        'Id': 26,
                        'Name': 'The Color Purple',
                        'Author': 'Alice Walker',
                        'Price': 15.49,
                        'Stock': 25,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Classics']
                      },
                      {
                        'Id': 27,
                        'Name': 'The Chronicles of Narnia',
                        'Author': 'C.S. Lewis',
                        'Price': 18.29,
                        'Stock': 22,
                        'Status': 0,
                        'CategoryNames': ['Fantasy']
                      },
                      {
                        'Id': 28,
                        'Name': 'A Song of Ice and Fire',
                        'Author': 'George R.R. Martin',
                        'Price': 22.99,
                        'Stock': 10,
                        'Status': 0,
                        'CategoryNames': ['Fantasy', 'Epic']
                      },
                      {
                        'Id': 29,
                        'Name': 'The Lord of the Rings',
                        'Author': 'J.R.R. Tolkien',
                        'Price': 25.99,
                        'Stock': 18,
                        'Status': 1,
                        'CategoryNames': ['Fantasy', 'Epic']
                      },
                      {
                        'Id': 30,
                        'Name': 'The Book Thief',
                        'Author': 'Markus Zusak',
                        'Price': 16.49,
                        'Stock': 20,
                        'Status': 0,
                        'CategoryNames': ['Historical Fiction']
                      },
                      {
                        'Id': 31,
                        'Name': 'The Grapes of Wrath',
                        'Author': 'John Steinbeck',
                        'Price': 14.99,
                        'Stock': 15,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Classics']
                      },
                      {
                        'Id': 32,
                        'Name': 'The Odyssey',
                        'Author': 'Homer',
                        'Price': 17.79,
                        'Stock': 28,
                        'Status': 0,
                        'CategoryNames': ['Poetry', 'Classics']
                      },
                      {
                        'Id': 33,
                        'Name': 'The Road Less Traveled',
                        'Author': 'M. Scott Peck',
                        'Price': 19.49,
                        'Stock': 18,
                        'Status': 0,
                        'CategoryNames': ['Self-Help', 'Psychology']
                      },
                      {
                        'Id': 34,
                        'Name': 'The Brothers Karamazov',
                        'Author': 'Fyodor Dostoevsky',
                        'Price': 21.99,
                        'Stock': 22,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Classics']
                      },
                      {
                        'Id': 35,
                        'Name': 'The Three Musketeers',
                        'Author': 'Alexandre Dumas',
                        'Price': 14.99,
                        'Stock': 15,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Adventure']
                      },
                      {
                        'Id': 36,
                        'Name': 'The Princess Bride',
                        'Author': 'William Goldman',
                        'Price': 16.99,
                        'Stock': 30,
                        'Status': 1,
                        'CategoryNames': ['Fiction', 'Fantasy']
                      },
                      {
                        'Id': 37,
                        'Name': 'The Secret Garden',
                        'Author': 'Frances Hodgson Burnett',
                        'Price': 12.99,
                        'Stock': 25,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Children']
                      },
                      {
                        'Id': 38,
                        'Name': 'The Count of Monte Cristo',
                        'Author': 'Alexandre Dumas',
                        'Price': 23.49,
                        'Stock': 20,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Adventure']
                      },
                      {
                        'Id': 39,
                        'Name': 'The Wind in the Willows',
                        'Author': 'Kenneth Grahame',
                        'Price': 15.99,
                        'Stock': 18,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Children']
                      },
                      {
                        'Id': 40,
                        'Name': 'The Picture of Dorian Gray',
                        'Author': 'Oscar Wilde',
                        'Price': 18.99,
                        'Stock': 15,
                        'Status': 0,
                        'CategoryNames': ['Fiction', 'Classics']
                      }
                    ]"))
            {
                Book book;

                int num = rand.Next(1, 11);

                book = new SimpleBook();

                book.Id = Convert.ToInt32(data["Id"]);
                book.Name = data["Name"].ToString();
                book.Author = data["Author"].ToString();
                book.Price = Convert.ToSingle(data["Price"]);
                book.Stock = Convert.ToInt32(data["Stock"]);
                book.Status = (BookStatus)Convert.ToInt32(data["Status"]);
                book.CategoryNames = new List<string>();

                foreach (var cat in data["CategoryNames"])
                {
                    book.CategoryNames.Add(cat.ToString());

                    if (!categories.Contains(cat.ToString()))
                        categories.Add(cat.ToString());
                }

                if (num >= 1 && num <= 2)
                    book = new BookMark(book);
                else if (num >= 3 && num <= 4)
                    book = new BookWrap(book);
                else if (num >= 5 && num <= 6)
                    book = new SpecialBook(book);

                shop.Books.Add(book);

                Console.WriteLine("Description: {0}\nPrice: {1}$\n", book.GetDescription(), book.Cost());
            }

            foreach (string cat in categories)
            {
                shop.Categories.Add(new Category
                {
                    Name = cat,
                    CreationDate = DateTime.Now.AddDays(rand.Next(1, 30) * -1)
                });
            }

            MessageBox.Show(string.Format("Added {0} categories and {1} books.", shop.Categories.Count, shop.Books.Count), "Data Loaded", MessageBoxButton.OK, MessageBoxImage.Information);
            Settings.Save();
        }
    }
}

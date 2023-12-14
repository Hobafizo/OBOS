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

		private void OnSettings()
		{
			Settings.Load();

			/*Shop shop = Shop.GetInstance();

			shop.Categories.Add(new Category
			{
				Name = "Category 1",
				CreationDate = DateTime.Now
			});

			Category readcat = new Category
			{
				Name = "Read Only",
				CreationDate = DateTime.Now.AddDays(-2)
			};
			shop.Categories.Add(readcat);

			Book book = new SimpleBook
			{
				Id = 1,
				Name = "The fault in our stars",
				Author = "HB",
				Price = 500,
				Stock = 50,
				Status = BookStatus.Available
			};

			book.AssignCategory(readcat);
			shop.Books.Add(book);

			shop.Users.Add(new Customer
			{
				Id = 1,
				UserName = "hb",
				Password = "123456",
				Address = "12 Wolf Street",
				Phone = "01008191389",
				Cart = new List<CartItem>()
				{
					new CartItem(book, 2)
				}
			});

			Order order = new Order
			{
				Id = 1,
				Customer = shop.Users[0],
				Date = DateTime.Now.AddDays(-5)
			};

			order.Items.Add(new CartItem(book, 5));

			shop.Orders.Add(order);

			Settings.Save();*/
		}
	}
}

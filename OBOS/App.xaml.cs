using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using OBOS.ViewModels;
using OBOS.Models.Store;

namespace OBOS
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        protected override void OnStartup(StartupEventArgs e)
        {
            SimpleBook book = new SimpleBook();
            book.Name = "The fault in our scars";
            book.Author = "Smeh";
            book.Price = 500;
            book.Stock = 15;
            book.Status = BookStatus.Available;

            SpecialBook special = new SpecialBook(book);
        
            MessageBox.Show("Your price is " + special.Clone().Cost().ToString() + " bolbol\n\n" + special.Clone().GetDescription(), "Test");

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}

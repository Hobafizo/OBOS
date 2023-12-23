using OBOS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OBOS.Views
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class BookView : UserControl
    {
        int count;
        public BookView(BookViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            count = 1;
            Price.Content = "EGP: " + (((BookViewModel)DataContext).Book.Price * count).ToString();
        }

        private void Decrement_Click(object sender, RoutedEventArgs e)
        {
            if (count > 1)
            {
                count--;
                Count.Text = count.ToString();
                Price.Content = "EGP: " + (((BookViewModel)DataContext).Book.Price * count).ToString();
            }
        }

        private void Increment_Click(object sender, RoutedEventArgs e)
        {
            if (count <= ((BookViewModel)DataContext).Book.Stock)
            {
                count++;
                Price.Content = "EGP: " + (((BookViewModel)DataContext).Book.Price * count).ToString();
                Count.Text = count.ToString();
            }
        }


        private void Count_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext != null)
                ((dynamic)DataContext).Count = count;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).Count = count;
            
            Count.Text = count.ToString();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            float x = 0;
            if (((CheckBox)sender).ContentStringFormat == "Book of the year")
                x += 50;
            if (((CheckBox)sender).ContentStringFormat == "Gift wrap")
                x += 60;
            if (((CheckBox)sender).ContentStringFormat == "Bookmark")
                x += 20;
            Price.Content = "EGP: " + ((((BookViewModel)DataContext).Book.Price + x) * count).ToString();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

            Price.Content = "EGP: " + ((((BookViewModel)DataContext).Book.Price) * count).ToString();
        }
    }
}

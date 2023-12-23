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
using OBOS.ViewModels;

namespace OBOS.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();

            LeftCategory.Click += LeftCategory_Click;
            RightCategory.Click += RightCategory_Click;
            LeftBook.Click += LeftBook_Click;
            RightBook.Click += RightBook_Click;

            AddCategory.Click += AddCategory_Click;
            DeleteCategory.Click += DeleteCategory_Click;
        }

        private void LeftCategory_Click(object sender, RoutedEventArgs e)
        {
            ((AdminViewModel)DataContext).IncreaseCategoryIndex(-1);
        }

        private void RightCategory_Click(object sender, RoutedEventArgs e)
        {
            ((AdminViewModel)DataContext).IncreaseCategoryIndex(1);
        }

        private void LeftBook_Click(object sender, RoutedEventArgs e)
        {
            ((AdminViewModel)DataContext).IncreaseBookIndex(-1);
        }

        private void RightBook_Click(object sender, RoutedEventArgs e)
        {
            ((AdminViewModel)DataContext).IncreaseBookIndex(1);
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            ((AdminViewModel)DataContext).DeleteCategory();
        }

        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            ((AdminViewModel)DataContext).DeleteCategory();
        }
    }
}

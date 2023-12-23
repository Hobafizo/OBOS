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
    /// Interaction logic for NewBookView.xaml
    /// </summary>
    public partial class NewBookView : UserControl
    {
        public NewBookView()
        {
            InitializeComponent();

            AddBook.Click += AddBook_Click;
        }

        private void Cats_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var cat in ((NewBookViewModel)DataContext).Categories)
            {
                Cats.Items.Add(cat.Name);
            }
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            ((NewBookViewModel)DataContext).AddBook((string)Cats.SelectedItem);
        }
    }
}

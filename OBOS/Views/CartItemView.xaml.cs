using OBOS.Models.Store;
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
    /// Interaction logic for CartItemView.xaml
    /// </summary>
    public partial class CartItemView : UserControl
    {
        public CartItem Item {  get; set; }

        public CartItemView(CartItemViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            Name.Content = "Name: " + viewModel.Name;
            Quantity.Content = "Quantity: " + viewModel.Quantity;
            Price.Content = "EGP: " + viewModel.Total;
            Item = viewModel.cartItem;

        }

        public event EventHandler<RoutedEventArgs> Clicked;
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Clicked?.Invoke(this, e);
        }
    }
}

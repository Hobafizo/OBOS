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
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView : UserControl
    {
        public CartView()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(DataContext != null)
            {

                if (((dynamic)DataContext).Cart == null|| ((dynamic)DataContext).Cart.Count == 0)
                {
                    Order.IsEnabled = false;
                }
                else
                {
                    foreach (var item in ((dynamic)DataContext).Cart)
                    {
                        CartItemView view = new CartItemView(new CartItemViewModel(item)) { Margin = new Thickness(0, 0, 0, 10) };
                        view.Clicked += Remove_Click;
                        Cart.Children.Add(view);
                    }

                    Total.Content = "Total: EGP " + ((dynamic)DataContext).Total;
                }

            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            ((CartViewModel)DataContext).Cart.Remove(((CartItemView)sender).Item);
            Cart.Children.Remove((dynamic)sender);
            
        }
    }
}

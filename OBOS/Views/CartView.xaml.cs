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
                foreach(var item in ((dynamic)DataContext).Cart)
                {
                    Cart.Children.Add(new CartItemView(new CartItemViewModel(item)) { Margin = new Thickness(0, 0, 0, 10) });
                }

                if(((dynamic)DataContext).Cart.Count==0)
                {
                    Order.IsEnabled = false;
                }
            }
        }
    }
}

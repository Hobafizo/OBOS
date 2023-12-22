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
    /// Interaction logic for StoreView.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        List<string> categories;

        public StoreView()
        {
            InitializeComponent();
            categories = new List<string>();
            All.Checked += CategoryAdded;
            All.Unchecked += CategoryRemoved;
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext != null)
            {
                foreach (var item in ((dynamic)DataContext).Categories)
                {
                    CheckBox checkBox = new CheckBox()
                    {
                        Content = item.Name,
                        ContentStringFormat = item.Name,
                        Style = FindResource("Cat") as Style
                    };

                    checkBox.Checked += CategoryAdded;
                    checkBox.Unchecked += CategoryRemoved;
                    Categories.Children.Add(checkBox);
                }
            }
        }

        private void CategoryRemoved(object sender, RoutedEventArgs e)
        {
            categories.Remove(((CheckBox)sender).ContentStringFormat);
            ((dynamic)DataContext).Filters = categories;
        }

        private void CategoryAdded(object sender, RoutedEventArgs e)
        {
            if(((CheckBox)sender).ContentStringFormat == "All")
            {
                for(int i=1;i<Categories.Children.Count;i++)
                {
                    ((CheckBox)Categories.Children[i]).IsChecked = false;
                    categories.Remove(((CheckBox)Categories.Children[i]).ContentStringFormat);
                }
            }

            categories.Add(((CheckBox)sender).ContentStringFormat);
            ((dynamic)DataContext).Filters = categories;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchBox.Text))
                All.IsChecked = false;
            ((dynamic)DataContext).Search = SearchBox.Text;
        }

        private void All_Checked(object sender, RoutedEventArgs e)
        {
            SearchBox.Clear();
        }
    }
}

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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(DataContext != null)
            {
                /*
                foreach (var item in ((dynamic)DataContext).TopSellers)
                {
                    BookViewModel viewModel = new BookViewModel(item);
                    BookView book = new BookView(viewModel)
                    {
                        Margin = new Thickness(20, 0, 0, 0)
                    };
                    Top.Children.Add(book);
                }
                */
                foreach (var item in ((dynamic)DataContext).Latest)
                {
                    BookViewModel viewModel = new BookViewModel(item);
                    BookView book = new BookView(viewModel)
                    {
                        Margin = new Thickness(20, 0, 0, 0)
                    };
                    Latest.Children.Add(book);
                }
            }
        }
    }
}

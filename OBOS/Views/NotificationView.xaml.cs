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
    /// Interaction logic for NotificationView.xaml
    /// </summary>
    public partial class NotificationView : UserControl
    {
        public NotificationView(NotificationViewModel notificationViewModel)
        {
            InitializeComponent();
            DataContext = notificationViewModel;
        }

        private void deny_Click(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).IsApproved = false;
        }

        private void approve_Click(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).IsApproved = true;

        }
    }
}

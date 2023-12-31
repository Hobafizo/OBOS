﻿using OBOS.ViewModels;
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
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (DataContext != null)
            {
                NoResult.Visibility = Visibility.Collapsed;

                int x = 20, y = 20;

                foreach (var item in ((dynamic)DataContext).SearchResult)
                {
                    BookViewModel viewModel = new BookViewModel(item);
                    BookView book = new BookView(viewModel);
                    Canvas.Children.Add(book);
                    Canvas.SetLeft(book, x);
                    Canvas.SetTop(book, y);
                    x += 236;
                    if (x > 1000)
                    {
                        x = 20;
                        y += 236;
                    }
                }

                if (Canvas.Children.Count == 0)
                {
                    NoResult.Visibility = Visibility.Visible;
                    return;
                }
            }
        }
    }
}

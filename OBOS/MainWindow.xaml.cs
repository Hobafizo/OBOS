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

namespace OBOS
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (Mouse.GetPosition(this).Y < 30)
			{
				this.Left = Mouse.GetPosition(this).Y;
				this.Top = Mouse.GetPosition(this).X;
			}
		}

		private void Window_DragEnter(object sender, DragEventArgs e)
		{
			if (Mouse.GetPosition(this).Y < 30)
			{
				this.Left = Mouse.GetPosition(this).X;
				this.Top = Mouse.GetPosition(this).Y;
			}
		}
	}
}

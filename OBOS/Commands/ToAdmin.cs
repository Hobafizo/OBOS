using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Stores;
using OBOS.ViewModels;

namespace OBOS.Commands
{
	public class ToAdmin : CommandBase
	{
		private readonly NavigationStore _navigationStore;

		public ToAdmin(NavigationStore navigationStore)
		{
			_navigationStore = navigationStore;
		}

		public override void Execute(object parameter)
		{
			_navigationStore.CurrentViewModel = new AdminViewModel(_navigationStore);
		}
	}
}

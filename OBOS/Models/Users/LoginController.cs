using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Users
{
	public class LoginController
	{
		public static LoginController Controller;

		public User CurrentUser { get; private set; }

		private LoginController()
		{
			Controller = null;
			CurrentUser = null;
		}

		public bool Login(string username, string pw)
		{
			return false;
		}

		public bool Register(string username, string pw, string confirmpw, string address, string phone, bool isadmin = false)
		{
			return false;
		}

		public bool Logout()
		{
			return false;
		}

		public static LoginController GetInstance()
		{
			if (Controller == null)
				Controller = new LoginController();
			return Controller;
		}
	}
}

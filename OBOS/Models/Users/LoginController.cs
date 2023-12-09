using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Store;


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
       
			//Users.Add(user);

		public bool Login(string username, string pw)
		{
			foreach (var user in Shop.GetInstance().Users)
			{
				if (CurrentUser.UserName == user.UserName)
				{
					CurrentUser = user;
					return true;
				}
			}
			return false;	
		}

		public bool Register(string username, string pw, string confirmpw, string address, string phone, bool isadmin = false)
		{

			foreach (var user1 in Shop.GetInstance().Users)
			{
				if (username == user1.UserName)
				{
					return false;

				}
			}
			User user;
			if (isadmin == true)
			{
				user = new Admin();
			}
			else
				user = new Customer();

			user.Id = User.IdCounter;
			user.UserName = username;
			user.Password = pw;
			if (pw != confirmpw)
			{
				return false;
			}
			user.Address = address;
			user.Phone = phone;
			User.IdCounter++;
			Shop.GetInstance().Users.Add(user);
			CurrentUser = user;

			return true;
		}
        

		public bool Logout()
		{
			if (CurrentUser == null)
			{
				return false;
			}

            CurrentUser = null;
			return true;

        }

        public static LoginController GetInstance()
		{
			if (Controller == null)
				Controller = new LoginController();
			return Controller;
		}
	}
}

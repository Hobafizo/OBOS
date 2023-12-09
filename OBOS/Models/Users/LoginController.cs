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
			Shop.GetInstance().Users.Add(user);

		public bool Login(string username, string pw)
		{
			foreach (var user in Shop.GetInstance().Users)
			{
				if (CurrentUser.UserName == user.UserName)
				{
					CurrentUser = true;
				}
				else
					return false;
			}
		}

		public bool Register(string username, string pw, string confirmpw, string address, string phone, bool isadmin = false)
		{
			User user;
			foreach (var user1 in Shop.GetInstance().Users)		
            if (user.UserName != user1.UserName)
            {
                User.Id = IdCounter;
                user.UserName = username;
                user.Password = pw;
                if (pw != confirmpw)
                {
                    return false;
                }
                user.Address = address;
                user.Phone = phone;
				IdCounter++;
                return true;
            }
			else return false;
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

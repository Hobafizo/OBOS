using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Users
{
    public abstract class User
    {
		// <<<< Attributes here >>>>

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
    }
}

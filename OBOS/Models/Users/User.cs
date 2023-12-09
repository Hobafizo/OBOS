using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OBOS.Models.Store;

namespace OBOS.Models.Users

{
    public abstract class User
    {
        public static IdCounter = 1 ;
        public int Id { get; set; };
        public string UserName { get; set; };
        public string Password { get; set; };
        public string Address { get; set; };
        public int Phone { get; set; };
        public Boolean IsAdmin { get; set; };

		public bool Login(string username, string pw)
        {
            return false;
        }

        public bool Register(string UserName, string Password, string Address, string Phone, bool isadmin = false)
        {
            this.Id = IdCounter;
            this.UserName = UserName;
            this.Password = Password;
            this.Address = Address; 
            this.Phone = Phone;
            Shop.GetInstance();
        }

        public bool Logout()
        {
            return false;
        }
    }
}

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
        public static int IdCounter = 1;

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        protected User(int id, string userName, string password, string address, string phone)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Address = address;
            Phone = phone;
        }

        public User()
        {

        }
    }
}

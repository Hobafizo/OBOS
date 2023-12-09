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
        public int Phone { get; set; }
        public bool IsAdmin { get; set; }
    }
}

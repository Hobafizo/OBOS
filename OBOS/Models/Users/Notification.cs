using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Users
{
	public class Notification
	{
        public string Message { get; set; }
        public DateTime Time { get; set; }

		bool IsApproved { get; set; }



	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Store
{
	public class SimpleBook : Book
	{
		public SimpleBook()
		{

		}

		public SimpleBook(float price)
		{
			Price = price;
		}

		public override Book Clone()
		{
			return new SimpleBook(Price);
		}
	}
}

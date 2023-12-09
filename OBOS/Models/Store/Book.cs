using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Store
{
	public enum BookStatus
	{
		Available,
		OutOfStock
	}

	public abstract class Book
	{
		// <<<< Attributes here >>>>
		public float Price { protected get; set; }

		public float Cost()
		{
			return Price;
		}

		public void AssignCategory(Category category)
		{

		}

		public void UnassignCategory(Category category)
		{

		}

		public abstract Book Clone();
	}
}

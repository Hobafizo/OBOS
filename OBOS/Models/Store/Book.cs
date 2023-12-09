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

        public string Name { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }		
        public float Price { protected get; set; }
        public int Stock { get; set; }
        public BookStatus Status { get; set; }
        public List<Category> Categories { get; set; }

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

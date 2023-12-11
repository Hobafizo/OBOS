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
		
        public int Id { get; set; }
        public string Name { get; set; }
		public string Author { get; set; }		
		public float Price { protected get; set; }
		public int Stock { get; set; }
		public BookStatus Status { get; set; }
		public List<Category> Categories { get; set; }
		// additional attribute 
		//public List<float> rating;


        public Book()
        {
            Categories = new List<Category>();
        }

        public abstract float Cost();
        public abstract string GetDescription();

		public void AssignCategory(Category category)
		{
			Categories.Add(category);
		}

		public void UnassignCategory(Category category)
		{
			Categories.Remove(category);
		}

		public abstract Book Clone();
	}
}

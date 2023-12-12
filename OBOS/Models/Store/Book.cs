using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OBOS.Models.Store
{
	public enum BookStatus
	{
		Available,
		OutOfStock
	}

	public abstract class Book
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Author { get; set; }		
		public float Price { get; set; }
        public int Stock { get; set; }
		public BookStatus Status { get; set; }

        public List<string> CategoryNames { get; set; }

        private List<Category> m_categories;

        [JsonIgnore]
        public List<Category> Categories
        {
            get
            {
                if (m_categories == null)
                    m_categories = Shop.GetInstance().GetCategories(CategoryNames);
                return m_categories;
            }

            set
            {
                CategoryNames = value.Select(x => x.Name).ToList();
                m_categories = value;
            }
        }

		// additional attribute 
		//public List<float> rating;


        public Book()
        {
            CategoryNames = new List<string>();
        }

        public abstract float Cost();
        public abstract string GetDescription();

		public void AssignCategory(Category category)
		{
            CategoryNames.Add(category.Name);
            Categories.Add(category);
		}

		public void UnassignCategory(Category category)
		{
            CategoryNames.Remove(category.Name);
			Categories.Remove(category);
		}

		public abstract Book Clone();
	}
}

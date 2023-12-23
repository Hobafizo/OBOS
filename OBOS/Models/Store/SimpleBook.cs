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

        public override float Cost()
        {
            return Price;
        }

        public override string GetDescription()
        {
            return Name;
        }

        public override Book Clone()
		{
            Book book = new SimpleBook();

            book.Id = Id;
            book.Name = Name;
            book.Author = Author;
            book.Price = Price;
            book.Stock = Stock;
            book.Status = Status;
            book.Categories = Categories;
            book.CategoryNames = CategoryNames;

            return book;
        }
	}
}

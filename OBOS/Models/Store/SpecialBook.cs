using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Store
{
	public class SpecialBook : BookDecorator
	{
		private Book BaseBook;

		public SpecialBook(Book book)
		{
			BaseBook = book;
        }

        public override float Cost()
		{
			return BaseBook.Cost() + 50;
		}

        public override string GetDescription()
        {
            return BaseBook.GetDescription() + " (special edition)";
        }

        public override Book Clone()
		{
			Book book = new SpecialBook(BaseBook);

            book.Id = Id;
            book.Name = Name;
            book.Author = Author;
            book.Price = Price;
            book.Stock = Stock;
            book.Status = Status;
            book.Categories = Categories;

            return book;
        }
	}
}

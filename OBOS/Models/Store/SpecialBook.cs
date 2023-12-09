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

		public SpecialBook(float price, Book book)
		{
			Price = price;
			BaseBook = book;
		}

		public override float Cost()
		{
			return Price + BaseBook.Cost();
		}

		public void AssignCategory(Category category)
		{

		}

		public void UnassignCategory(Category category)
		{

		}

		public override Book Clone()
		{
			return new SpecialBook(Price, BaseBook);
		}
	}
}

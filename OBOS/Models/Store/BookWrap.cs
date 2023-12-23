using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Store
{
    public class BookWrap : BookDecorator
    {
        private Book BaseBook;

        public BookWrap(Book book)
        {
            BaseBook = book;
            Id = BaseBook.Id;
            Name = BaseBook.Name;
            Author = BaseBook.Author;
            Stock = BaseBook.Stock;
            Status = BaseBook.Status;
            Categories = BaseBook.Categories;
        }

        public override float Cost()
        {
            return BaseBook.Cost() + 60;
        }

        public override string GetDescription()
        {
            return BaseBook.GetDescription() + ", Book Wrap";
        }

        public override Book Clone()
        {
            Book book = new BookWrap(BaseBook);

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

using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Store
{
    public class BookMark : BookDecorator
    {
        private Book BaseBook;

        public BookMark(Book book)
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
            return BaseBook.Cost() + 20;
        }

        public override string GetDescription()
        {
            return BaseBook.GetDescription() + ", Bookmark";
        }

        public override Book Clone()
        {
            Book book = new BookMark(BaseBook);

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

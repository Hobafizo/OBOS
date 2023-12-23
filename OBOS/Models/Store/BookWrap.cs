using OBOS.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OBOS.Models.Store
{
    public class BookWrap : BookDecorator
    {
        public Book BaseBook { get; set; }

        public BookWrap(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            Price = book.Price;
            Stock = book.Stock;
            Status = book.Status;
            Categories = book.Categories;
            CategoryNames = book.CategoryNames;

            BaseBook = book;
        }

        [JsonConstructor]
        public BookWrap(int id, string name, string author, float price, int stock, BookStatus status, List<string> categories, Book book)
        {
            Id = id;
            Name = name;
            Author = author;
            Price = price;
            Stock = stock;
            Status = status;
            CategoryNames = categories;

            BaseBook = book;
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
            book.CategoryNames = CategoryNames;

            return book;
        }
    }
}

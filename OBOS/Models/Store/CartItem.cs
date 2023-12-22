using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace OBOS.Models.Store
{
    public class CartItem
    {
        public int BookId { get; set; }

        private Book m_book;

        [JsonIgnore]
        public Book Book
        {
            get
            {
                if (m_book == null)
                    m_book = Shop.GetInstance().GetBook(BookId);
                return m_book;
            }

            set
            {
                BookId = value.Id;
                m_book = value;
            }
        }

        public int Quantity { get; set; }

        [JsonConstructor]
        public CartItem(int bookid, int quantity = 0)
        {
            BookId = bookid;
            Quantity = quantity;
        }

        public CartItem(Book book, int quantity = 0)
        {
            Book = book;
            Quantity = quantity;
        }

        public float Total()
        {
            return Book.Cost() * Quantity;
        }
    }
}

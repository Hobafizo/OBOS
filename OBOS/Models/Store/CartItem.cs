using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Store
{
    public class CartItem
    {
        public Book Book { get; }
        public int Quantity { get; set; }

        public CartItem(Book book, int quantity = 0)
        {
            Book = book;
            Quantity = quantity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Users
    ;
using OBOS.Models.Store;

namespace OBOS.Models.Payments
{
    public class Order
    {
        public int Id { get; set; }
        public User Customer { get; set; }
        public List<CartItem> Items { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public Order()
        {
            Items = new List<CartItem>();
        }

        public float TotalCost()
        {
            float TotalPrice = 0;

            foreach(var item in Items)
            {
                TotalPrice += item.Book.Cost() * (float)item.Quantity;
            }
            return TotalPrice;
        }
    }
}

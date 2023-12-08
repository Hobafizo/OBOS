using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models
{
    public class Order
    {
        private int Id { get; set; }
        private User Customer { get; set; }
        private List<KeyValuePair<Book, int>> Items { get; set; }
        private int Quantity { get; set; }
        private float TotalPrice { get; set; }
        private DateTime Date { get; set; }

        public float Total()
        {
            TotalPrice = 0;
            foreach(var item in Items)
            {
                TotalPrice += item.Key.Price * (float)item.Value;
            }
            return TotalPrice;
        }
    }
}

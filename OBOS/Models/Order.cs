﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User Customer { get; set; }
        public List<KeyValuePair<Book, int>> Items { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public DateTime Date { get; set; }

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

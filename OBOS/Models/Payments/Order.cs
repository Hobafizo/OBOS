using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBOS.Models.Users;
using OBOS.Models.Store;
using Newtonsoft.Json;

namespace OBOS.Models.Payments
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        private User m_customer;
        [JsonIgnore]
        public User Customer
        {
            get
            {
                if (m_customer == null)
                    m_customer = Shop.GetInstance().GetUser(CustomerId);
                return m_customer;
            }

            set
            {
                CustomerId = value.Id;
                m_customer = value;
            }
        }

        public List<CartItem> Items { get; set; }
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

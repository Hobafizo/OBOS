using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models
{
    public class Category
    {
        private string Name { get; set; }
        private DateTime CreationDate { get; set; }

        Order order;
        public Category()
        {
            
        }
    }
}

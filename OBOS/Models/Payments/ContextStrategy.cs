using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Payments
{
    public class ContextStrategy 
    {
        public IPaymentStartegy paymentStartegy { get; set; }

        public ContextStrategy() { 
        }

        public ContextStrategy(IPaymentStartegy paymentStartegy)
        {
            this.paymentStartegy = paymentStartegy;
        }

        public bool Pay(float amount)
        {
            return paymentStartegy.Pay(amount);
        }
    }
}

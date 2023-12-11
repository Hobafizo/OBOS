using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Payments
{
    public class CashPayment : IPaymentStartegy
    {
        public bool Pay(double amount)
        {
            //Console.WriteLine("Paid using CreditCard", amount);
            return true;
        }
    }
}

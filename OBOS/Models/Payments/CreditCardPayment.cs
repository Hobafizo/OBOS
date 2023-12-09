using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Payments
{
	public class CreditCardPayment : IPaymentStartegy
	{
        public string CardID { get; set; }
        public string ExpiryDate { get; set; }
        public short CVV { get; set; }
        public string HolderName { get; set; } 

        public CreditCardPayment(string CardID, string ExpiryDate, short CVV, string HolderName)
        {
            this.CardID = CardID;
            this.ExpiryDate = ExpiryDate;
            this.CVV = CVV;
            this.HolderName = HolderName;   
        }

        public CreditCardPayment()
        {
        }

        public void Pay(double amount)
		{
            Console.WriteLine("Paid using CreditCard",amount,CardID,CVV,HolderName,ExpiryDate);
			
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Payments
{
	public class CreditCardPayment : IPaymentStartegy
	{
		// <<<< Attributes here >>>>

		public bool Pay()
		{
			return false;
		}
	}
}
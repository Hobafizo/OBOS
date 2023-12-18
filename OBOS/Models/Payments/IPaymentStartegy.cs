using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBOS.Models.Payments
{
    public interface IPaymentStartegy
    {
        bool Pay(float amount);
    }
}

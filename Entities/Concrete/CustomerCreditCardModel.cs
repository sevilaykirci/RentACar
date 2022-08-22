using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CustomerCreditCardModel
    {
        public int CustomerId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}

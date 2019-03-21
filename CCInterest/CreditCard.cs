using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCInterest
{
    public class CreditCard
    {
        public CCType CreditCardType { get; set; }
        public decimal InterestCalculated { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public string CCNumber { get; set; }
    }
}

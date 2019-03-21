using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCInterest
{
    public class Wallet
    {
        public string Name { get; set; }
        public List<CreditCard> Cards { get; set; }

        public decimal TotalCalculatedInterest { get; set; }
    }
}

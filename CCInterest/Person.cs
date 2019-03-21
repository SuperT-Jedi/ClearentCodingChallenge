using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCInterest
{
    public class Person
    {
        public List<Wallet> Wallets { get; set; }

        public decimal CalculatedInterest { get; set; }
    }
}

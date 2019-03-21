using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCInterest
{
    public static class CCFunctions
    {
        private static decimal CalculateInterest(CreditCard cc)
        {
            decimal ir = 0;
            switch (cc.CreditCardType)
            {
                case CCType.Visa:
                    ir = cc.CurrentBalance * 0.1m;
                    break;
                case CCType.MasterCard:
                    ir = cc.CurrentBalance * 0.05m;
                    break;
                case CCType.Discover:
                    ir = cc.CurrentBalance * 0.01m;
                    break;
            }
            return ir;
        }


        public static void CalculateIR_PerCard(Person p)
        {
            foreach (Wallet w in p.Wallets)
            {
                foreach (CreditCard cc in w.Cards)
                {
                    cc.InterestCalculated = CalculateInterest(cc);
                }
            }
        }
    }
}

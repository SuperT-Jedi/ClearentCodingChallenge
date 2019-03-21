using System;
using System.Collections.Generic;
using System.Linq;
using CCInterest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_CCInterest
{
    [TestClass]
    public class TestCC
    {
        [TestMethod]
        public void TestCase1()
        {
            Person p = new Person();
            p.Wallets = new List<Wallet>();
            p.Wallets.Add(new Wallet() { Name = "3 cards" });
            p.Wallets[0].Cards = new List<CreditCard>();

            CreditCard cc = new CreditCard()
            {
                CreditCardType = CCType.Visa,
                CurrentBalance = 100
            };
            p.Wallets[0].Cards.Add(cc);

            cc = new CreditCard()
            {
                CreditCardType = CCType.MasterCard,
                CurrentBalance = 100
            };
            p.Wallets[0].Cards.Add(cc);

            cc = new CreditCard()
            {
                CreditCardType = CCType.Discover,
                CurrentBalance = 100
            };
            p.Wallets[0].Cards.Add(cc);

            CCFunctions.CalculateIR_PerCard(p);

            foreach (Wallet w in p.Wallets)
            {
                decimal totalIR = 0;
                foreach (CreditCard c in w.Cards)
                {
                    totalIR += c.InterestCalculated;
                }
                w.TotalCalculatedInterest = totalIR;
            }
            
            p.CalculatedInterest = p.Wallets[0].TotalCalculatedInterest;

            // Check values of test case

            Assert.AreEqual(p.Wallets.Count, 1, "Invalid number of wallets. Expected 1");
            Assert.AreEqual(p.Wallets[0].Cards.Count, 3, "Invalid number of credit cards. Expected 3");

            Assert.AreEqual(p.CalculatedInterest, 16m, "Invalid interest. Expected 16");

            Assert.AreEqual(p.Wallets[0].Cards.First(x=>x.CreditCardType==CCType.Visa).InterestCalculated, 10m, "Invalid interest for Visa. Expected 10");
            Assert.AreEqual(p.Wallets[0].Cards.First(x => x.CreditCardType == CCType.MasterCard).InterestCalculated, 5m, "Invalid interest for MC. Expected 5");
            Assert.AreEqual(p.Wallets[0].Cards.First(x => x.CreditCardType == CCType.Discover).InterestCalculated, 1m, "Invalid interest for Discover. Expected 1");
        }

        [TestMethod]
        public void TestCase2()
        {
            Person p = new Person();
            p.Wallets = new List<Wallet>();
            Wallet wlt = new Wallet() { Name = "2 Cards" };


            wlt.Cards = new List<CreditCard>();

            CreditCard cc = new CreditCard()
            {
                CreditCardType = CCType.Visa,
                CurrentBalance = 100
            };
            wlt.Cards.Add(cc);

           
            cc = new CreditCard()
            {
                CreditCardType = CCType.Discover,
                CurrentBalance = 100
            };
            wlt.Cards.Add(cc);
            p.Wallets.Add(wlt);


            wlt = new Wallet() { Name = "1 Card" };
            wlt.Cards = new List<CreditCard>();
            cc = new CreditCard()
            {
                CreditCardType = CCType.MasterCard,
                CurrentBalance = 100
            };
            wlt.Cards.Add(cc);
            p.Wallets.Add(wlt);

            CCFunctions.CalculateIR_PerCard(p);

            foreach (Wallet w in p.Wallets)
            {
                decimal totalIR = 0;
                foreach (CreditCard c in w.Cards)
                {
                    totalIR += c.InterestCalculated;
                }
                w.TotalCalculatedInterest = totalIR;
                p.CalculatedInterest += totalIR;
            }

            // Check values of test case

            Assert.AreEqual(p.Wallets.Count, 2, "Invalid number of wallets. Expected 2");
            Assert.AreEqual(p.Wallets.First(x => x.Name == "2 Cards").Cards.Count, 2, "Invalid number of credit cards. Expected 2");
            Assert.AreEqual(p.Wallets.First(x => x.Name == "1 Card").Cards.Count, 1, "Invalid number of credit cards. Expected 1");

            Assert.AreEqual(p.CalculatedInterest, 16m, "Invalid interest. Expected 16");

            Assert.AreEqual(p.Wallets.First(x => x.Name=="2 Cards").TotalCalculatedInterest, 11m, "Invalid interest for Wallet 2 Cards. Expected 11");
            Assert.AreEqual(p.Wallets.First(x => x.Name == "1 Card").TotalCalculatedInterest, 5m, "Invalid interest for Wallet 1 Card. Expected 5");
        }

        [TestMethod]
        public void TestCase3()
        {
            Person p = new Person();
            p.Wallets = new List<Wallet>();
            Wallet wlt = new Wallet() { Name = "2 Cards" };


            wlt.Cards = new List<CreditCard>();

            CreditCard cc = new CreditCard()
            {
                CreditCardType = CCType.MasterCard,
                CurrentBalance = 100
            };
            wlt.Cards.Add(cc);

            cc = new CreditCard()
            {
                CreditCardType = CCType.Visa,
                CurrentBalance = 100
            };
            wlt.Cards.Add(cc);
            
            p.Wallets.Add(wlt);

            CCFunctions.CalculateIR_PerCard(p);

            foreach (Wallet w in p.Wallets)
            {
                decimal totalIR = 0;
                foreach (CreditCard c in w.Cards)
                {
                    totalIR += c.InterestCalculated;
                }
                w.TotalCalculatedInterest = totalIR;
                p.CalculatedInterest += totalIR;
            }

            // Check values of test case

            Assert.AreEqual(p.Wallets.Count, 1, "Invalid number of wallets. Expected 1");
            Assert.AreEqual(p.Wallets.First(x => x.Name == "2 Cards").Cards.Count, 2, "Invalid number of cards. Expected 2");

            Assert.AreEqual(p.CalculatedInterest, 15m, "Invalid interest for person 1. Expected 15");

            Assert.AreEqual(p.Wallets.First(x => x.Name == "2 Cards").TotalCalculatedInterest, 15m, "Invalid interest for Wallet. Expected 15");

            p = new Person();
            p.Wallets = new List<Wallet>();
            wlt = new Wallet() { Name = "2 Cards" };
            wlt.Cards = new List<CreditCard>();
            cc = new CreditCard()
            {
                CreditCardType = CCType.Visa,
                CurrentBalance = 100
            };
            wlt.Cards.Add(cc);
            cc = new CreditCard()
            {
                CreditCardType = CCType.MasterCard,
                CurrentBalance = 100
            };
            wlt.Cards.Add(cc);
            p.Wallets.Add(wlt);

            CCFunctions.CalculateIR_PerCard(p);

            foreach (Wallet w in p.Wallets)
            {
                decimal totalIR = 0;
                foreach (CreditCard c in w.Cards)
                {
                    totalIR += c.InterestCalculated;
                }
                w.TotalCalculatedInterest = totalIR;
                p.CalculatedInterest += totalIR;
            }

            // Check values of test case

            Assert.AreEqual(p.Wallets.Count, 1, "Invalid number of wallets. Expected 1");
            Assert.AreEqual(p.Wallets.First(x => x.Name == "2 Cards").Cards.Count, 2, "Invalid number of cards. Expected 2");

            Assert.AreEqual(p.CalculatedInterest, 15m, "Invalid interest for person 2. Expected 15");

            Assert.AreEqual(p.Wallets.First(x => x.Name == "2 Cards").TotalCalculatedInterest, 15m, "Invalid interest for wallet. Expected 15");
        }

    }
}

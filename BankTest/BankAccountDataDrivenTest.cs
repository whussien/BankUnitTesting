using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using System.Diagnostics;

namespace BankTest
{
    [TestClass]
    public class BankAccountDataDrivenTest
    {
        private TestContext context;
        private static BankAccount bankAccount;
        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }

        [ClassInitialize]
        public static void ClassStartup(TestContext context)
        {
            var Name = "Ahmed Mohamed Rashad";
            var Balance = 10;

            bankAccount = new BankAccount(Name, Balance);
        }

        [TestMethod(),
         TestProperty("TestPass", "Accessibility")]
        public void Debit_WithValideAmount_UpdatesBalance1()
        {
            double debitAmount = 5;
            double expectedBalance = 5;

            bankAccount.Debit(debitAmount);

            double actualBalance = bankAccount.Balance;

            Assert.AreEqual(expectedBalance, actualBalance, 0.001, "expected and actual balance are not equal");
        }
        [TestMethod(),
         TestProperty("TestPass", "Accessibility")]
        public void Debit_WithValideAmount_UpdatesBalance2()
        {
            double debitAmount = 5;
            double expectedBalance = 0;

            bankAccount.Debit(debitAmount);

            double actualBalance = bankAccount.Balance;

            Assert.AreEqual(expectedBalance, actualBalance, 0.001, "expected and actual balance are not equal");
        }
        [TestMethod(),
        TestCategory("Accessibility")]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WithAmountLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            double debitAmount = -5;            

            bankAccount.Debit(debitAmount);
        }
        
    }
}

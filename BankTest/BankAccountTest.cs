using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;

namespace BankTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void Debit_WithValideAmount_UpdatesBalance()
        {
            double startOfBalance = 10;
            double debitAmount = 5;
            double expectedBalance = 5;

            var bankAccount = new BankAccount("Ahmed Mohamed", startOfBalance);
            bankAccount.Debit(debitAmount);

            double actualBalance = bankAccount.Balance;

            Assert.AreEqual(expectedBalance, actualBalance, 0.001, "expected and actual balance are not equal");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WithAmountLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            double startOfBalance = 10;
            double debitAmount = -5;            

            var bankAccount = new BankAccount("Ahmed Mohamed", startOfBalance);
            bankAccount.Debit(debitAmount);
        }

        [TestMethod]
        public void Debit_WithAmountMoreThanBalance_ThrowsArgumentOutOfRangeException()
        {
            double startOfBalance = 10;
            double debitAmount = 15;

            var bankAccount = new BankAccount("Ahmed Mohamed", startOfBalance);
            try
            {
                bankAccount.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Equals(ex.Message, BankAccount.AMOUNT_MORE_THAN_BALANCE);
                return;
            }

            Assert.Fail("No Exception Thrown");            
        }
        
        [TestMethod]
        public void BankAccount_MultipleObjects_AllCorrect()
        {
            var bankAccount = new BankAccount[3];
            bankAccount[0] = new BankAccount("Ahmed", 11);
            bankAccount[1] = new BankAccount("Ahmed", 13);
            bankAccount[2] = new BankAccount("Ahmed", 15);
            
            CollectionAssert.AllItemsAreInstancesOfType(bankAccount, typeof(BankAccount));
        }

        [TestMethod]
        public void BankAccount_MultipleObjects_NotCorrect()
        {
            var objectList = new List<object>();

            objectList.Add(new BankAccount("Ahmed", 11));
            objectList.Add(new BankAccount("Ahmed", 13));
            objectList.Add(new BankAccount("Ahmed", 15));
            objectList.Add("string");
            objectList.Add(new Boolean());
            
            CollectionAssert.AllItemsAreNotNull(objectList);
        }

        [TestMethod]
        public void ValidBankCode_WorkingFine()
        {
            var bankAccount1 = new BankAccount("Ahmed", 11, "12345");
            var bankAccount2 = new BankAccount("Mohamed", 11, "ABCDE");
            var bankAccount3 = new BankAccount("Rashad", 11, "#123HA");

            BankAssert.IsValidBankCode("12345");
        }

        [TestMethod]
        public void InCompleted_Test_Method()
        {
            Assert.Inconclusive("Incompleted test");
        }

        [TestMethod]
        [Ignore]
        public void InCompleted_Test_Method_With_Ignore()
        {
            Assert.Inconclusive("Incompleted test");
        }
    }
}

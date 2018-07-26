using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest
{
    class BankAssert
    {
        private static string DefaultMessage = "non valid bank code";

        public static void IsValidBankCode(string Code)
        {
            IsValidBankCode(Code, DefaultMessage);
        }

        public static void IsValidBankCode(string Code, string Message)
        {
            if (!BankAccount.AllBankCodes.Contains(Code))
            {
                throw new AssertFailedException(Message);
            }
        }
    }
}

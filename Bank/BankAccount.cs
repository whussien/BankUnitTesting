using System;
using System.Collections.Generic;

namespace Bank
{
    /// <summary>   
    /// Bank Account demo class.   
    /// </summary>   
    public class BankAccount
    {
        public const string AMOUNT_LESS_THAN_ZERO = "amount cannot be less than 0";
        public const string AMOUNT_MORE_THAN_BALANCE = "amount cannot be more than balance";
        public const string FROZEN_ACCOUNT = "account frozen";

        private static List<string> m_validBankCodes = new List<string>();

        private string m_customerName;

        private string m_customerCode;

        private double m_balance;

        private bool m_frozen = false;

        private BankAccount()
        {
        }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public BankAccount(string customerName, double balance, string customerCode)
        {
            m_customerName = customerName;
            m_customerCode = customerCode;
            m_balance = balance;

            m_validBankCodes.Add(customerCode);
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public string CustomerCode
        {
            get { return m_customerCode; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public static List<string> AllBankCodes
        {
            get { return m_validBankCodes;  }
        }
        public void Debit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception(FROZEN_ACCOUNT);
            }

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount", amount, AMOUNT_MORE_THAN_BALANCE);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, AMOUNT_LESS_THAN_ZERO);
            }

            m_balance -= amount; // intentionally incorrect code  
        }

        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception(FROZEN_ACCOUNT);
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, AMOUNT_LESS_THAN_ZERO);
            }

            m_balance += amount;
        }

        private void FreezeAccount()
        {
            m_frozen = true;
        }

        private void UnfreezeAccount()
        {
            m_frozen = false;
        }


        public static void Main()
        {
            BankAccount ba = new BankAccount("Mr. Bryan Walton", 11.99);

            ba.Credit(5.77);
            ba.Debit(11.22);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }

    }
}
using System;
using System.IO;

namespace BankingProject
{
    public abstract class Account
    {
        public string Username { get; set; }
        protected decimal balance;
        public Account(string username, decimal initialBalance)
        {
            Username = username;
            balance = initialBalance;
        }
        public Account() { }
        public virtual void Deposit(decimal amount)
        {
            balance += amount;
        }
        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }
        public decimal GetBalance()
        {
            return balance;
        }
        public void SaveToFile()
        {
            string accountType = (this is CheckingAccount) ? "Checking" : "Savings";
            string filename = Username + "_" + accountType + ".txt";
            File.WriteAllText(filename, accountType + ";" + balance);
        }
        public static Account LoadFromFile(string username, string accountType)
        {
            string filename = username + "_" + accountType + ".txt";
            if (!File.Exists(filename))
                return null;
            string[] parts = File.ReadAllText(filename).Split(';');
            if (parts.Length != 2)
                return null;
            decimal bal = Convert.ToDecimal(parts[1]);
            if (accountType == "Checking")
                return new CheckingAccount(username, bal);
            else if (accountType == "Savings")
                return new SavingsAccount(username, bal);
            return null;
        }
    }
}

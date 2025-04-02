using System;

namespace BankingProject
{
    public class Deposit : Transaction
    {
        public Deposit(Account account, decimal amount) : base(account, amount) { }
        public Deposit() { }
        public override void ProcessTransaction()
        {
            Account.Deposit(Amount);
            Account.SaveToFile();
            Console.WriteLine("Deposited " + Amount.ToString("C") + " on " + TransactionDate.ToString());
        }
    }
}

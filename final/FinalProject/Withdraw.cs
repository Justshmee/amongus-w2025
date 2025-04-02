using System;

namespace BankingProject
{
    public class Withdraw : Transaction
    {
        public Withdraw(Account account, decimal amount) : base(account, amount) { }
        public Withdraw() { }
        public override void ProcessTransaction()
        {
            if (Account.Withdraw(Amount))
            {
                Account.SaveToFile();
                Console.WriteLine("Withdrew " + Amount.ToString("C") + " on " + TransactionDate.ToString());
            }
            else
            {
                Console.WriteLine("Withdrawal of " + Amount.ToString("C") + " failed on " + TransactionDate.ToString());
            }
        }
    }
}

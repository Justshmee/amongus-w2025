using System;

namespace BankingProject
{
    public abstract class Transaction
    {
        public Account Account { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Transaction(Account account, decimal amount)
        {
            Account = account;
            Amount = amount;
            TransactionDate = DateTime.Now;
        }
        public Transaction() { }
        public abstract void ProcessTransaction();
    }
}

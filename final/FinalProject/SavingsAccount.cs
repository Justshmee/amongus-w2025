namespace BankingProject
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string username, decimal initialBalance) : base(username, initialBalance) { }
        public SavingsAccount() { }
        public void AddInterest(decimal interestRate)
        {
            balance += balance * interestRate;
        }
    }
}

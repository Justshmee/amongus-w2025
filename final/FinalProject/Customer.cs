namespace BankingProject
{
    public class Customer
    {
        public string Username { get; set; }
        public Account Account { get; set; }
        public Customer(string username, Account account)
        {
            Username = username;
            Account = account;
        }
        public Customer() { }
    }
}

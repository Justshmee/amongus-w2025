using System;

namespace BankingProject
{
    public class Bank
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Select account type:");
            Console.WriteLine("1. Checking");
            Console.WriteLine("2. Savings");
            Console.Write("Choose an option: ");
            string typeChoice = Console.ReadLine();
            string accountType = (typeChoice == "1") ? "Checking" : (typeChoice == "2") ? "Savings" : "";
            if (accountType == "")
            {
                Console.WriteLine("Invalid account type. Exiting.");
                return;
            }
            Account account = Account.LoadFromFile(username, accountType);
            Customer customer;
            if (account == null)
            {
                Console.WriteLine("No " + accountType + " account found. Creating new account.");
                Console.Write("Enter initial deposit: ");
                decimal initialDeposit = Convert.ToDecimal(Console.ReadLine());
                if (accountType == "Checking")
                {
                    account = new CheckingAccount(username, initialDeposit);
                }
                else if (accountType == "Savings")
                {
                    account = new SavingsAccount(username, initialDeposit);
                }
                account.SaveToFile();
                customer = new Customer(username, account);
                Console.WriteLine(accountType + " account created for " + username);
            }
            else
            {
                Console.WriteLine(accountType + " account loaded for " + username);
                customer = new Customer(username, account);
            }
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n1. Deposit\n2. Withdraw\n3. Check Balance\n4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Write("Enter deposit amount: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    Deposit deposit = new Deposit(customer.Account, depositAmount);
                    deposit.ProcessTransaction();
                }
                else if (choice == "2")
                {
                    Console.Write("Enter withdrawal amount: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    Withdraw withdraw = new Withdraw(customer.Account, withdrawAmount);
                    withdraw.ProcessTransaction();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Current Balance: " + customer.Account.GetBalance());
                }
                else if (choice == "4")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
            }
        }
    }
}

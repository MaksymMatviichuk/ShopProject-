using System;
using BankSystem.Models;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("12345");
        SavingsAccount savingsAccount1 = new SavingsAccount("67890", 5);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Display Bank Account Balance");
            Console.WriteLine("2. Deposit to Bank Account");
            Console.WriteLine("3. Withdraw from Bank Account");
            Console.WriteLine("4. Display Savings Account Balance");
            Console.WriteLine("5. Deposit to Savings Account");
            Console.WriteLine("6. Add Interest to Savings Account");
            Console.WriteLine("7. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    account1.DisplayBalance();
                    break;
                case "2":
                    Console.Write("Enter the amount to deposit to the bank account: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    account1.Deposit(depositAmount);
                    break;
                case "3":
                    Console.Write("Enter the amount to withdraw from the bank account: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    account1.Withdraw(withdrawAmount);
                    break;
                case "4":
                    savingsAccount1.DisplayBalance();
                    break;
                case "5":
                    Console.Write("Enter the amount to deposit to the savings account: ");
                    decimal savingsDepositAmount = Convert.ToDecimal(Console.ReadLine());
                    savingsAccount1.Deposit(savingsDepositAmount);
                    break;
                case "6":
                    savingsAccount1.AddInterest();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select an option from the menu.");
                    break;
            }
        }
    }
}

using BankSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class BankAccount : IBankAccount
    {
        private string accountNumber;
        private decimal balance;

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        // Konstruktor
        public BankAccount(string accountNumber)
        {
            this.accountNumber = accountNumber;
            this.balance = 0;
        }

        // Metoda do wpłacania środków
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

        // Metoda do wypłacania środków
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
            }
        }

        // Metoda do wyświetlania salda
        public virtual void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance:C}");
        }
    }
}

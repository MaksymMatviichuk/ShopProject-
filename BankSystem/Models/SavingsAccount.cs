using BankSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    public class SavingsAccount : BankAccount, ISavingsAccount
    {
        private decimal interestRate;

        public decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        // Konstruktor
        public SavingsAccount(string accountNumber, decimal interestRate) : base(accountNumber)
        {
            this.interestRate = interestRate;
        }

        // Metoda do dodawania odsetek
        public void AddInterest()
        {
            decimal interest = Balance * (InterestRate / 100);
            Deposit(interest);
            Console.WriteLine($"Added interest: {interest:C}. New balance: {Balance:C}");
        }

        // Przesłonięta metoda do wyświetlania salda, aby uwzględniała stopę procentową
        public override void DisplayBalance()
        {
            base.DisplayBalance();
            Console.WriteLine($"Interest Rate: {InterestRate}%");
        }
    }
}

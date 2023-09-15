using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Interfaces
{
    public interface IBankAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void DisplayBalance();
    }
}

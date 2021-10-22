using System;
using System.Collections.Generic;
using System.Text;

namespace BankKata
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Transactions { get; }

        void Deposit(int amount);

        void Withdraw(int amount);
    }
}
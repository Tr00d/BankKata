using System.Collections.Generic;

namespace BankKata
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> Transactions { get; }

        void Deposit(int amount);

        void Withdraw(int amount);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace BankKata
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ITimeProvider _timeProvider;
        private readonly List<Transaction> _transactions;

        public TransactionRepository(ITimeProvider timeProvider)
        {
            this._timeProvider = timeProvider;
            this._transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> Transactions => new List<Transaction>(this._transactions);

        public void Deposit(int amount)
        {
            this.AddTransaction(amount);
        }

        public void Withdraw(int amount)
        {
            this.AddTransaction(-amount);
        }

        private void AddTransaction(int amount)
        {
            this._transactions.Add(new Transaction
            {
                Amount = amount,
                Date = this._timeProvider.UtcNow
            });
        }
    }
}
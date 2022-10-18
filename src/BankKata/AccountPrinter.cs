using System;
using System.Collections.Generic;
using System.Linq;

namespace BankKata
{
    public class AccountPrinter : IAccountPrinter
    {
        public const string DateFormat = "dd/MM/yyyy";
        public const string StatementHeader = "DATE | AMOUNT | BALANCE";

        public static readonly Func<Transaction, int, string> Formatter = (Transaction transaction, int balance) =>
            $"{transaction.Date.ToString(DateFormat)} | {transaction.Amount} | {balance}";

        private readonly ITextConsole _console;

        public AccountPrinter(ITextConsole console)
        {
            this._console = console;
        }

        public void PrintTransactions(IEnumerable<Transaction> transactions)
        {
            this._console.WriteLine(StatementHeader);
            foreach (var statement in this.ParseTransactions(transactions))
            {
                this._console.WriteLine(Formatter(statement.Transaction, statement.Balance));
            }
        }

        private IEnumerable<AggregateTransaction> ParseTransactions(IEnumerable<Transaction> transactions)
        {
            var formattedTransactions = new List<AggregateTransaction>();
            _ = transactions
                .OrderBy(transaction => transaction.Date)
                .Select(transaction => new AggregateTransaction(transaction))
                .Aggregate(default(int), (runningBalance, transaction) =>
                {
                    runningBalance += transaction.Transaction.Amount;
                    formattedTransactions.Add(new AggregateTransaction(transaction.Transaction, runningBalance));
                    return runningBalance;
                });
            return formattedTransactions
                .OrderByDescending(statement => statement.Transaction.Date);
        }

        private struct AggregateTransaction
        {
            public AggregateTransaction(Transaction transaction, int balance = default)
            {
                this.Transaction = transaction;
                this.Balance = balance;
            }

            public Transaction Transaction { get; }

            public int Balance { get; }
        }
    }
}
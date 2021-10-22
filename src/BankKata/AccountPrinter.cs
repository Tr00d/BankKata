using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankKata
{
    public class AccountPrinter : IAccountPrinter
    {
        public const string dateFormat = "dd/MM/yyyy";
        public const string statementHeader = "DATE | AMOUNT | BALANCE";
        public static readonly Func<Transaction, int, string> formatter = (Transaction transaction, int balance) => $"{transaction.Date.ToString(AccountPrinter.dateFormat)} | {transaction.Amount} | {balance}";
        private ITextConsole _console;

        public AccountPrinter(ITextConsole console)
        {
            this._console = console;
        }

        public void PrintTransactions(IEnumerable<Transaction> transactions)
        {
            this._console.WriteLine(statementHeader);
            int runningBalance = 0;
            foreach (var statement in transactions
                .OrderBy(transaction => transaction.Date)
                .Select(transaction => new { Transaction = transaction, Balance = runningBalance += transaction.Amount })
                .ToList()
                .OrderByDescending(statement => statement.Transaction.Date))
            {
                this._console.WriteLine(formatter(statement.Transaction, statement.Balance));
            }
        }
    }
}
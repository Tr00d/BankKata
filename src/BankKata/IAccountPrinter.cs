using System;
using System.Collections.Generic;
using System.Text;

namespace BankKata
{
    public interface IAccountPrinter
    {
        void PrintTransactions(IEnumerable<Transaction> transactions);
    }
}
using System.Collections.Generic;

namespace BankKata
{
    public interface IAccountPrinter
    {
        void PrintTransactions(IEnumerable<Transaction> transactions);
    }
}
namespace BankKata
{
    public class Account : IAccount
    {
        private readonly IAccountPrinter _printer;
        private readonly ITransactionRepository _transactionRepository;

        public Account(ITransactionRepository transactionRepository, IAccountPrinter printer)
        {
            this._transactionRepository = transactionRepository;
            this._printer = printer;
        }

        public void Deposit(int amount)
        {
            this._transactionRepository.Deposit(amount);
        }

        public void PrintStatements()
        {
            this._printer.PrintTransactions(this._transactionRepository.Transactions);
        }

        public void Withdraw(int amount)
        {
            this._transactionRepository.Withdraw(amount);
        }
    }
}
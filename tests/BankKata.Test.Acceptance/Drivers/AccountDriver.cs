using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BankKata.Test.Acceptance.Drivers
{
    public class AccountDriver
    {
        private readonly Account _account;
        private readonly ITextConsole _console;
        private readonly IAccountPrinter _printer;
        private readonly ITransactionRepository _repository;
        private readonly StringWriter _stringWriter;
        private readonly Mock<ITimeProvider> _timeProvider;

        public AccountDriver()
        {
            this._stringWriter = new StringWriter();
            this._console = new TextConsole();
            this._timeProvider = new Mock<ITimeProvider>();
            this._printer = new AccountPrinter(this._console);
            this._repository = new TransactionRepository(this._timeProvider.Object);
            this._account = new Account(this._repository, this._printer);
            Console.SetOut(this._stringWriter);
        }

        public void Deposit(int amount, DateTime date)
        {
            this.SetupTimeProvider(date);
            this._account.Deposit(amount);
        }

        public string GetConsoleOutput()
        {
            return this._stringWriter.ToString();
        }

        public void PrintStatements()
        {
            this._account.PrintStatements();
        }

        public void Withdraw(int amount, DateTime date)
        {
            this.SetupTimeProvider(date);
            this._account.Withdraw(amount);
        }

        private void SetupTimeProvider(DateTime date)
        {
            this._timeProvider.Setup(provider => provider.UtcNow).Returns(date);
        }
    }
}
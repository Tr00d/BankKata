using Moq;
using NUnit.Framework;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;

namespace BankKata.Test.Acceptance.Steps
{
    [Binding]
    public class AccountSteps
    {
        private readonly Account _account;
        private readonly ITextConsole _console;
        private readonly IAccountPrinter _printer;
        private readonly ITransactionRepository _repository;
        private readonly ScenarioContext _scenarioContext;
        private readonly StringWriter _stringWriter;
        private readonly Mock<ITimeProvider> _timeProvider;

        public AccountSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            this._stringWriter = new StringWriter();
            this._console = new TextConsole();
            this._timeProvider = new Mock<ITimeProvider>();
            this._printer = new AccountPrinter(this._console);
            this._repository = new TransactionRepository(this._timeProvider.Object);
            this._account = new Account(this._repository, this._printer);
            Console.SetOut(this._stringWriter);
        }

        [Given(@"I make a deposit of (.*) on '(.*)'")]
        public void GivenIMakeADepositOfOn(int amount, string date)
        {
            this._timeProvider.Setup(provider => provider.UtcNow).Returns(DateTime.ParseExact(date, AccountPrinter.dateFormat, CultureInfo.InvariantCulture));
            this._account.Deposit(amount);
        }

        [Given(@"I make a withdrawal of (.*) on '(.*)'")]
        public void GivenIMakeAWithdrawalOfOn(int amount, string date)
        {
            this._timeProvider.Setup(provider => provider.UtcNow).Returns(DateTime.ParseExact(date, AccountPrinter.dateFormat, CultureInfo.InvariantCulture));
            this._account.Withdraw(amount);
        }

        [Then(@"I should see all statements in reverse chronological order")]
        public void ThenIShouldSeeAllStatementsInReverseChronologicalOrder()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DATE | AMOUNT | BALANCE");
            builder.AppendLine("20/01/2021 | -500 | 2500");
            builder.AppendLine("15/01/2021 | 2000 | 3000");
            builder.AppendLine("10/01/2021 | 1000 | 1000");
            Assert.AreEqual(builder.ToString(), this._stringWriter.ToString());
        }

        [When(@"I prints the account statements")]
        public void WhenIPrintsTheAccountStatements()
        {
            this._account.PrintStatements();
        }
    }
}
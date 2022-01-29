using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BankKata.Test.Acceptance.Drivers;
using BankKata.Test.Acceptance.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BankKata.Test.Acceptance.Steps
{
    [Binding]
    public class AccountSteps
    {
        private readonly AccountDriver driver;

        public AccountSteps(AccountDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I make a deposit of (.*) on '(.*)'")]
        public void GivenIMakeADepositOfOn(int amount, string date)
        {
            this.driver.Deposit(amount,
                DateTime.ParseExact(date, AccountPrinter.dateFormat, CultureInfo.InvariantCulture));
        }

        [Given(@"I make a withdrawal of (.*) on '(.*)'")]
        public void GivenIMakeAWithdrawalOfOn(int amount, string date)
        {
            this.driver.Withdraw(amount,
                DateTime.ParseExact(date, AccountPrinter.dateFormat, CultureInfo.InvariantCulture));
        }

        [Then(@"I should see all statements in reverse chronological order")]
        public void ThenIShouldSeeAllStatementsInReverseChronologicalOrder()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DATE | AMOUNT | BALANCE");
            builder.AppendLine("20/01/2021 | -500 | 2500");
            builder.AppendLine("15/01/2021 | 2000 | 3000");
            builder.AppendLine("10/01/2021 | 1000 | 1000");
            Assert.AreEqual(builder.ToString(), this.driver.GetConsoleOutput());
        }

        [When(@"I prints the account statements")]
        public void WhenIPrintsTheAccountStatements()
        {
            this.driver.PrintStatements();
        }

        [Then(@"I should see these statements:")]
        public void ThenIShouldSeeTheseStatements(Table table)
        {
            IEnumerable<TestStatement> statements = table.CreateSet<TestStatement>();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("DATE | AMOUNT | BALANCE");
            statements.ToList().ForEach(statement =>
                builder.AppendLine($"{statement.Date} | {statement.Amount} | {statement.Balance}"));
            Assert.AreEqual(builder.ToString(), this.driver.GetConsoleOutput());
        }
    }
}
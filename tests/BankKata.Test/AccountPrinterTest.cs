using AutoFixture;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankKata.Test
{
    [TestFixture(Category = "Unit")]
    public class AccountPrinterTest
    {
        private Fixture _fixture;
        private Mock<ITextConsole> _mockConsole;

        [Test]
        public void PrintTransactions_ShouldWrirteTransactionsFromNewestToOldest()
        {
            Transaction firstTransaction = new Transaction { Date = new DateTime(2010, 08, 05), Amount = 2500 };
            Transaction secondTransaction = new Transaction { Date = new DateTime(2015, 01, 15), Amount = -500 };
            Transaction thirdTransaction = new Transaction { Date = new DateTime(2019, 10, 25), Amount = 50 };
            IEnumerable<Transaction> transactions = new List<Transaction>
            {
                secondTransaction,
                thirdTransaction,
                firstTransaction,
            };
            AccountPrinter printer = new AccountPrinter(this._mockConsole.Object);
            printer.PrintTransactions(transactions);
            this._mockConsole.Verify(console => console.WriteLine(It.IsAny<string>()), Times.Exactly(transactions.Count() + 1));
            Assert.AreEqual(this._mockConsole.Invocations[1].Arguments[0].ToString(), AccountPrinter.formatter(thirdTransaction, 2050));
            Assert.AreEqual(this._mockConsole.Invocations[2].Arguments[0].ToString(), AccountPrinter.formatter(secondTransaction, 2000));
            Assert.AreEqual(this._mockConsole.Invocations[3].Arguments[0].ToString(), AccountPrinter.formatter(firstTransaction, 2500));
        }

        [Test]
        public void PrintTransactions_ShouldWriteHeaderToConsole_GivenTransactionsAreEmpty()
        {
            AccountPrinter printer = new AccountPrinter(this._mockConsole.Object);
            printer.PrintTransactions(new List<Transaction>());
            this._mockConsole.Verify(console => console.WriteLine(AccountPrinter.statementHeader), Times.Once());
        }

        [SetUp]
        public void SetUp()
        {
            this._fixture = new Fixture();
            this._mockConsole = new Mock<ITextConsole>();
        }
    }
}
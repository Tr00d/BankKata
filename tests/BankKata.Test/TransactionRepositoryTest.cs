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
    public class TransactionRepositoryTest
    {
        private Fixture _fixture;
        private Mock<ITimeProvider> _mockTimeProvider;

        [Test]
        public void Deposit_ShouldAddDepositTransactionWithExpectedAmount()
        {
            int amount = this._fixture.Create<int>();
            TransactionRepository repository = new TransactionRepository(this._mockTimeProvider.Object);
            repository.Deposit(amount);
            Assert.AreEqual(1, repository.Transactions.Count());
            Assert.AreEqual(amount, repository.Transactions.First().Amount);
        }

        [Test]
        public void Deposit_ShouldAddDepositTransactionWithExpectedDate()
        {
            DateTime date = this._fixture.Create<DateTime>();
            this._mockTimeProvider.Setup(provider => provider.UtcNow).Returns(date);
            TransactionRepository repository = new TransactionRepository(this._mockTimeProvider.Object);
            repository.Deposit(this._fixture.Create<int>());
            Assert.AreEqual(1, repository.Transactions.Count());
            Assert.AreEqual(date, repository.Transactions.First().Date);
        }

        [SetUp]
        public void SetUp()
        {
            this._fixture = new Fixture();
            this._mockTimeProvider = new Mock<ITimeProvider>();
        }

        [Test]
        public void Withdraw_ShouldAddWithdrawalTransactionWithExpectedAmount()
        {
            int amount = this._fixture.Create<int>();
            TransactionRepository repository = new TransactionRepository(this._mockTimeProvider.Object);
            repository.Withdraw(amount);
            Assert.AreEqual(1, repository.Transactions.Count());
            Assert.AreEqual(-amount, repository.Transactions.First().Amount);
        }

        [Test]
        public void Withdraw_ShouldAddWithdrawalTransactionWithExpectedDate()
        {
            DateTime date = this._fixture.Create<DateTime>();
            this._mockTimeProvider.Setup(provider => provider.UtcNow).Returns(date);
            TransactionRepository repository = new TransactionRepository(this._mockTimeProvider.Object);
            repository.Withdraw(this._fixture.Create<int>());
            Assert.AreEqual(1, repository.Transactions.Count());
            Assert.AreEqual(date, repository.Transactions.First().Date);
        }
    }
}
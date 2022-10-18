using System;
using System.Linq;
using AutoFixture;
using Moq;
using NUnit.Framework;

namespace BankKata.Test
{
    [TestFixture(Category = "Unit")]
    public class TransactionRepositoryTest
    {
        [SetUp]
        public void SetUp()
        {
            this._fixture = new Fixture();
            this._mockTimeProvider = new Mock<ITimeProvider>();
        }

        private Fixture _fixture;
        private Mock<ITimeProvider> _mockTimeProvider;

        [Test]
        public void Deposit_ShouldAddDepositTransactionWithExpectedAmount()
        {
            var amount = this._fixture.Create<int>();
            var repository = new TransactionRepository(this._mockTimeProvider.Object);
            repository.Deposit(amount);
            Assert.AreEqual(1, repository.Transactions.Count());
            Assert.AreEqual(amount, repository.Transactions.First().Amount);
        }

        [Test]
        public void Deposit_ShouldAddDepositTransactionWithExpectedDate()
        {
            var date = this._fixture.Create<DateTime>();
            this._mockTimeProvider.Setup(provider => provider.UtcNow).Returns(date);
            var repository = new TransactionRepository(this._mockTimeProvider.Object);
            repository.Deposit(this._fixture.Create<int>());
            Assert.AreEqual(1, repository.Transactions.Count());
            Assert.AreEqual(date, repository.Transactions.First().Date);
        }

        [Test]
        public void Withdraw_ShouldAddWithdrawalTransactionWithExpectedAmount()
        {
            var amount = this._fixture.Create<int>();
            var repository = new TransactionRepository(this._mockTimeProvider.Object);
            repository.Withdraw(amount);
            Assert.AreEqual(1, repository.Transactions.Count());
            Assert.AreEqual(-amount, repository.Transactions.First().Amount);
        }

        [Test]
        public void Withdraw_ShouldAddWithdrawalTransactionWithExpectedDate()
        {
            var date = this._fixture.Create<DateTime>();
            this._mockTimeProvider.Setup(provider => provider.UtcNow).Returns(date);
            var repository = new TransactionRepository(this._mockTimeProvider.Object);
            repository.Withdraw(this._fixture.Create<int>());
            Assert.AreEqual(1, repository.Transactions.Count());
            Assert.AreEqual(date, repository.Transactions.First().Date);
        }
    }
}
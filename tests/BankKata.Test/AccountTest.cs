using AutoFixture;
using Moq;
using NUnit.Framework;

namespace BankKata.Test
{
    [TestFixture(Category = "Unit")]
    public class AccountTest
    {
        [SetUp]
        public void SetUp()
        {
            this._fixture = new Fixture();
            this._mockPrinter = new Mock<IAccountPrinter>();
            this._mockTransactionRepository = new Mock<ITransactionRepository>();
        }

        private Fixture _fixture;
        private Mock<IAccountPrinter> _mockPrinter;
        private Mock<ITransactionRepository> _mockTransactionRepository;

        [Test]
        public void Deposit_ShouldStoreDepositTransaction()
        {
            var amount = this._fixture.Create<int>();
            var account = new Account(this._mockTransactionRepository.Object, this._mockPrinter.Object);
            account.Deposit(amount);
            this._mockTransactionRepository.Verify(repository => repository.Deposit(amount), Times.Once());
        }

        [Test]
        public void PrintStatements_ShouldPrintTransactions()
        {
            var transactions = this._fixture.CreateMany<Transaction>();
            this._mockTransactionRepository.Setup(repository => repository.Transactions).Returns(transactions);
            var account = new Account(this._mockTransactionRepository.Object, this._mockPrinter.Object);
            account.PrintStatements();
            this._mockPrinter.Verify(printer => printer.PrintTransactions(transactions), Times.Once());
        }

        [Test]
        public void Withdraw_ShouldStoreWithdrawalTransaction()
        {
            var amount = this._fixture.Create<int>();
            var account = new Account(this._mockTransactionRepository.Object, this._mockPrinter.Object);
            account.Withdraw(amount);
            this._mockTransactionRepository.Verify(repository => repository.Withdraw(amount), Times.Once());
        }
    }
}
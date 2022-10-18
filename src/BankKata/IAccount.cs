namespace BankKata
{
    public interface IAccount
    {
        void Deposit(int amount);

        void PrintStatements();

        void Withdraw(int amount);
    }
}
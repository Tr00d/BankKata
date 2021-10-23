# Bank Kata following a double loop TDD Outside-In approach
The initial kata can be found here: https://github.com/sandromancuso/bank-kata-outsidein-screencast

The objective was to expose how the TDD outside-in approach can lead to a good design starting from an acceptance test. 

# Description
Create a simple bank application with the following features:

```
 - Deposit into Account
 - Withdraw from an Account
 - Print a bank statement to the console
```

## Acceptance criteria
Statements should have transactions in the following format ordered from newest to latest:

```
DATE | AMOUNT | BALANCE
20/01/2021 | -500 | 2500
15/01/2021 | 2000 | 3000
10/01/2021 | 1000 | 1000
```

## Constraints
The Account class should implement the following interface:

```
    public interface IAccount
    {
        void Deposit(int amount);
        void PrintStatements();
        void Withdraw(int amount);
    }
```

We are not allowed to add any other public method to this class.

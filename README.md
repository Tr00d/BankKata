# Bank Kata following a double loop TDD Outside-In approach
The initial kata can be found here: https://github.com/sandromancuso/bank-kata-outsidein-screencast

The objective was to expose how the TDD outside-in approach can lead to a good design starting from an acceptance test. 

# Kata description
Create a simple bank application with the following features:

```
 - User can deposit into Account
 - User can withdraw from an Account
 - User can print a bank statement to the console
```

## Acceptance criteria
Statements should have transactions in the following format ordered from newest to latest with a running balance:

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
This being a kata, we have to take shortcuts as we can't really provide a production application. So we'll simplify our design by using int values for amounts, not using any kind of database (or entities), etc.

## Process
* Start by creating a failing acceptance test. This is the expected output at the feature level. It might be weird at first but outside-in TDD forces to to write production code while creating your test as you need a specific dependency in order to read from the console.
* Create a failing unit test for Account and start expanding your design. 
* Make this test pass by writing the minimum required code.
* Refactor the code.
* Repeat.
* For every responsibility, create a specific component and mock it directly in your test.
* Your design will slowly grow until you cover all responsibilities required for you acceptance test
* The acceptance test should pass

## Conclusion
One aspect in particular of outside-in TDD might scare developers: you need to know your design at first. Still, this is not entirely true. Indeed, you need to have an idea of the different responsibilities involved but you don't have to know the details upfront. For example, I know I will have a repository but I don't really care about the method signature yet, I'll figure out when I need it. Your layers are designed progressively.

The double loop forces you to focus on the high level requirement instead of the domain. Every test/code that you write is to make sure the user will be able to perform these actions. Basically, you don't write code that has no use in the feature.

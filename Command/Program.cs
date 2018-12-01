using System;
using System.Collections.Generic;

namespace Command
{
    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            this.balance += amount;
            Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
        }

        public void Withdraw(int amount)
        {
            if (balance - amount >= this.overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew {amount}, balance is now {balance}");
            }
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public interface ICommand
    {
        void Call();
    }

    public class BankAccounCommand : ICommand
    {
        private BankAccount account;

        public enum Action
        {
            Deposit,
            Withdraw
        }

        private Action action;
        private int amount;

        public BankAccounCommand(BankAccount account, Action action, int amount)
        {
            this.account = account ?? throw new ArgumentException(nameof(account));
            this.action = action;
            this.amount = amount;
        }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    break;
                case Action.Withdraw:
                    account.Withdraw(amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var ba = new BankAccount();
            var commands = new List<BankAccounCommand>
            {
                new BankAccounCommand(ba, BankAccounCommand.Action.Deposit, 1000),
                new BankAccounCommand(ba, BankAccounCommand.Action.Withdraw, 300)
            };
            Console.WriteLine(ba);

            foreach (var command in commands)
            {
                command.Call();
            }

            Console.WriteLine(ba);
        }
    }
}
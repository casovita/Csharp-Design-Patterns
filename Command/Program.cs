using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool Withdraw(int amount)
        {
            if (balance - amount >= this.overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew {amount}, balance is now {balance}");
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public interface ICommand
    {
        void Call();
        void Undo();
    }

    public class BankAccounCommand : ICommand
    {
        private BankAccount _account;

        public enum Action
        {
            Deposit,
            Withdraw
        }

        private Action _action;
        private int _amount;
        private bool _succeeded;
        
        public BankAccounCommand(BankAccount account, Action action, int amount)
        {
            this._account = account ?? throw new ArgumentException(nameof(account));
            this._action = action;
            this._amount = amount;
        }

        public void Call()
        {
            switch (_action)
            {
                case Action.Deposit:
                    _account.Deposit(_amount);
                    _succeeded = true;
                    break;
                case Action.Withdraw:
                    _succeeded = _account.Withdraw(_amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            if(!_succeeded)return;
            
            switch (_action)
            {
                case Action.Deposit:
                    _account.Withdraw(_amount);
                    break;
                case Action.Withdraw:
                    _account.Deposit(_amount);
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

            foreach (var command in Enumerable.Reverse(commands))
            {
                command.Undo();
            }

            Console.WriteLine(ba);
        }
    }
}
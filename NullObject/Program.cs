using Autofac;
using ImpromptuInterface;
using System;
using System.Dynamic;

namespace NullObject
{
    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    public class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Warn(string msg)
        {
            Console.WriteLine("WARNING!!! " + msg);
        }
    }

    public class NullLog : ILog
    {
        public void Info(string msg)
        {
        }

        public void Warn(string msg)
        {
        }
    }

    public class Null<TInterface> : DynamicObject where TInterface : class
    {
        //Install-Package ImpromptuInterface -Version 7.0.1
        public static TInterface Instance => new Null<TInterface>().ActLike<TInterface>();

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }

    public class BankAccount
    {
        private ILog log;
        public int balance;

        public BankAccount(ILog log)
        {
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Deposit(int amount)
        {
            balance += amount;
            log.Info($"Deposited ${amount}. Balance = {balance}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var log = new ConsoleLog();
            //var ba = new BankAccount(log);
            //ba.Deposit(500);
            //ba.Deposit(500);

            //Install-Package Autofac -Version 4.9.0-beta1
            //var cb = new ContainerBuilder();
            //cb.RegisterType<BankAccount>();
            //cb.RegisterType<NullLog>().As<ILog>();
            //using (var c = cb.Build())
            //{
            //    var ba = c.Resolve<BankAccount>();
            //    ba.Deposit(500);
            //    ba.Deposit(500);
            //    Console.WriteLine("Balance = $" + ba.balance);
            //}


            //Dynamic Null Object
            var log = Null<ILog>.Instance;
            log.Info("Foo log");
            var ba = new BankAccount(log);
            ba.Deposit(200);
            Console.WriteLine("Balance = $" + ba.balance);
        }
    }
}

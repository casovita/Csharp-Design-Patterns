using System;

namespace Decorator.Multiple.Inheritance
{
    public interface IBird
    {
        void Fly();
        int Weight { get; set; }
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }
        
        public void Fly()
        {
            Console.WriteLine($"Soaring in the sky with weight {Weight}");
        }
    }

    public interface ILizard
    {
        void Crawl();
        int Weight { get; set; }
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            Console.WriteLine($"Crawling in the dirt with weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        private Bird _Bird = new Bird();
        private Lizard _Lizard = new Lizard();
        private int _Weight;

        public void Crawl()
        {
            _Lizard.Crawl();
        }

        public void Fly()
        {
            _Bird.Fly();
        }

        public int Weight
        {
            get => _Weight;
            set
            {
                _Weight = value;
                this._Bird.Weight = value;
                this._Lizard.Weight = value;
            }
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
            
            var d = new Dragon();
            d.Weight = 123;
            d.Fly();
            d.Crawl();
        }
    }
}
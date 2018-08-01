using System.Runtime.CompilerServices;

namespace Decorator.Coding.Exercise
{
    public class Bird
    {
        public int Age { get; set; }
      
        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }
      
        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        private int _Age;
        private Bird _Bird = new Bird();
        private Lizard _Lizard = new Lizard();
        public int Age
        {
            set => this._Age = this._Bird.Age = this._Lizard.Age = value;
            get => this._Age;
        }

        public string Fly() => this._Bird.Fly();

        public string Crawl() => this._Lizard.Crawl();
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
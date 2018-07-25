using System;

namespace Observer.Events
{
    public class FallsIllEventArgs
    {
        public string Address;
    }

    public class Person
    {
        public void CatchACold()
        {
            var listeners = FaillsIll?.GetInvocationList();
            if (listeners?.Length > 0)
            {
                Console.WriteLine($"Number of listeners: {listeners.Length}");
                FaillsIll?.Invoke(this, new FallsIllEventArgs
                    {Address = "LondonHerzel 12/33"});
            }
        }

        public event EventHandler<FallsIllEventArgs> FaillsIll;
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person();
            
            person.FaillsIll += CallDoctor;
            
            person.CatchACold();
            
            //Listening cancellation
            person.FaillsIll -= CallDoctor;

        }

        private static void CallDoctor(object sender, FallsIllEventArgs e)
        {
            Console.WriteLine($"A doctor has been called to {e.Address}");
        }
    }
}
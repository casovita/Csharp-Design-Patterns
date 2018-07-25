using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Coding.Execise
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private Person() { }

        public static class PersonFactory
        {
            private static int Id { get; set; } = 0;
            public static Person CreatePerson(string name)
            {

                var newPerson = new Person()
                {
                    Name = name,
                    Id = Id++
                };

                return newPerson;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = Person.PersonFactory.CreatePerson("Michael");
            var p2 = Person.PersonFactory.CreatePerson("Hamudi");
            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.ReadKey();
        }
    }
}

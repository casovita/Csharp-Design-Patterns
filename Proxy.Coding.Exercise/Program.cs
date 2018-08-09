namespace Proxy.Coding.Exercise
{
    public class Person
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson
    {
        private readonly int _ageToDrive = 16;
        private readonly int _ageToDrink = 18;
        private Person _person;

        public ResponsiblePerson(Person person)
        {
            this._person = person;
        }

        public int Age
        {
            get => this._person.Age;
            set => this._person.Age = value;
        }
        
        public string Drink()
        {
            if (Age >= _ageToDrink)
                return _person.Drink();
            return "too young";
        }

        public string Drive()
        {
            if (Age >= this._ageToDrive)
                return _person.Drive();
            return "too young";
        }

        public string DrinkAndDrive()
        {
            return "dead";
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Faceted
{
    public class Person
    {
        //adress
        public string StreetAdress, PostCode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAdress)}:{StreetAdress},{nameof(PostCode)}:{PostCode},{nameof(City)}:{City}," +
                $"{nameof(CompanyName)}:{CompanyName},{nameof(Position)}:{Position}, {nameof(AnnualIncome)}:{AnnualIncome}";
        }
    }

    public class PersonBuilder //facade
    {
        //reference!
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder personBuilder)
        {
            return personBuilder.person;
        }
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string steetAdress)
        {
            person.StreetAdress = steetAdress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode)
        {
            person.PostCode = postCode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            Person person = pb.Works
                .At("Facebook")
                .AsA("Developer")
                .Earning(1000)
                .Lives.At("Dolinski 5")
                .In("Rehovot")
                .WithPostCode("21346");

            Console.WriteLine(person.ToString());
            Console.ReadKey();
        }
    }
}

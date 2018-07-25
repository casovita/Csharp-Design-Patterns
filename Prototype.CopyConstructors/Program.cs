using System;

namespace Prototype.CopyConstructors
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class Address : IPrototype<Address>
    {
        public string StreetAddress, City, Country;

        public Address(string streetAddress, string city, string country)
        {
            StreetAddress = streetAddress ?? throw new ArgumentNullException(paramName: nameof(streetAddress));
            City = city ?? throw new ArgumentNullException(paramName: nameof(city));
            Country = country ?? throw new ArgumentNullException(paramName: nameof(country));
        }

        public Address(Address other)
        {
            StreetAddress = other.StreetAddress;
            City = other.City;
            Country = other.Country;
        }

        public Address DeepCopy()
        {
            return new Address(StreetAddress, City, Country);
        }

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }
    }

    public class Person : IPrototype<Person>
    {
        public readonly string[] Names;
        public readonly Address Address;

        public Person(string[] names, Address address)
        {
            Names = names ?? throw new ArgumentNullException(paramName: nameof(names));
            Address = address ?? throw new ArgumentNullException(paramName: nameof(address));
        }

        // CopyConstructor
        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);
        }

        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person(new[] {"Michael"}, new Address("Dolinski", "Rehovot", "Israel"));

            //  var copyPerson = new Person(person);
            var copyPerson = person.DeepCopy();
            copyPerson.Address.Country = "Italy";

            Console.WriteLine(person);
            Console.WriteLine(copyPerson);
            Console.ReadKey();
        }
    }
}
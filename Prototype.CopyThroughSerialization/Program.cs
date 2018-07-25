using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype.CopyThroughSerialization
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formater = new BinaryFormatter();
            formater.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);

            object copy = formater.Deserialize(stream);
            stream.Close();
            return (T) copy;
        }

        
        /// <summary>
        /// Must implement parameterless constructor of T for using XmlSerializer
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(ms, self);
                ms.Position = 0;
                return (T) xmlSerializer.Deserialize(ms);
            }
        }
    }

    [Serializable]
    public class Address
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

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Country)}: {Country}";
        }
    }

    [Serializable]
    public class Person
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

            var copyPerson = person.DeepCopy();
            copyPerson.Address.Country = "Italy";
            copyPerson.Names[0] = "Other Name";

            Console.WriteLine(person);
            Console.WriteLine(copyPerson);
            Console.ReadKey();
        }
    }
}
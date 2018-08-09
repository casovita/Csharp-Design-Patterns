using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows;
//using ImpromptuInterface;
//using JetBrains.dotMemoryUnit;
//using NUnit.Framework;
using static System.Console;

namespace Proxy.Property
{
    public class Property<T> : IEquatable<Property<T>> where T : new()
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (Equals(this._value, value)) return;
                WriteLine($"Assigning value to {value}");
                this._value = value;
            }
        }

        public Property() : this(Activator.CreateInstance<T>())
        {
        }

        public Property(T value)
        {
            _value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property._value; // int n p_int;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value); //Property<int> p = 123;
        }

        public bool Equals(Property<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Property<T>) obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(_value);
        }

        public static bool operator ==(Property<T> left, Property<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Property<T> left, Property<T> right)
        {
            return !Equals(left, right);
        }
    }
    
    public class Creature
    {
        private Property<int> agility = new Property<int>();

        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
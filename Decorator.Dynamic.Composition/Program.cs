﻿using System;

namespace Decorator.Dynamic.Composition
{
    public abstract class Shape
    {
        public virtual string AsString() => string.Empty;
    }

    public class Circle : Shape
    {
        private float _Radius;

        public Circle() : this(0)
        {
      
        }

        public Circle(float radius)
        {
            this._Radius = radius;
        }

        public void Resize(float factor)
        {
            _Radius *= factor;
        }

        public override string AsString() => $"A circle of radius {_Radius}";
    }
    
    public class Square : Shape
    {
        private float side;

        public Square() : this(0)
        {
      
        }

        public Square(float side)
        {
            this.side = side;
        }

        public override string AsString() => $"A square with side {side}";
    }
    
    // dynamic
    public class ColoredShape : Shape
    {
        private Shape shape;
        private string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }

        public override string AsString() => $"{shape.AsString()} has the color {color}";
    }
    
    public class ColoredShape<T> : Shape where T : Shape, new()
    {
        private string color;
        private T shape = new T();

        public ColoredShape() : this("black")
        {
      
        }

        public ColoredShape(string color) // no constructor forwarding
        {
            this.color = color ?? throw new ArgumentNullException(paramName: nameof(color));
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }
    
    public class TransparentShape : Shape
    {
        private Shape shape;
        private float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape ?? throw new ArgumentNullException(paramName: nameof(shape));
            this.transparency = transparency;
        }

        public override string AsString() => $"{shape.AsString()} has {transparency * 100.0f}% transparency";
    }
    
    public class TransparentShape<T> : Shape where T : Shape, new()
    {
        private float transparency;
        private T shape = new T();

        public TransparentShape(float transparency)
        {
            this.transparency = transparency;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has transparency {transparency * 100.0f}%";
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var square = new Square(1.23f);
            Console.WriteLine(square.AsString());
            
            var redSquare = new ColoredShape(square,"RED");
            Console.WriteLine(redSquare.AsString());
            
            var redHalfTransparentSquare = new TransparentShape(redSquare,0.5f);
            Console.WriteLine(redHalfTransparentSquare.AsString());
            
            var blackHalfSquare = new TransparentShape<ColoredShape<Square>>(0.4f);
            Console.WriteLine(blackHalfSquare.AsString());
        }
    }
}
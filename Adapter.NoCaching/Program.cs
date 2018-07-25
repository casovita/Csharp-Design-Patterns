using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Adapter.NoCaching
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point end, Point start)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            End = end ?? throw new ArgumentNullException(nameof(end));
        }
    }

    public class VectorObject : Collection<Line>
    {
    }

    public class Rectangle : VectorObject
    {
        public Rectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x, y), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x + width, y + height)));
        }
    }


    internal class Program
    {
        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>
        {
            
        };
        
        public static void Main(string[] args)
        {
        }
    }
}
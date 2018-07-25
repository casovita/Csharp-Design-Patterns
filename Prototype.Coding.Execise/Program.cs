namespace Prototype.Coding.Execise
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point DeepCopy(Point other)
        {
            return new Point(other.X, other.Y);
        }
    }

    public class Line
    {
        public Point _Start, _End;

        public Line(Point start, Point end)
        {
            this._Start = start;
            this._End = end;
        }

        public Line DeepCopy()
        {
            return new Line(new Point(_Start.X,_Start.Y),new Point(_End.X,_End.Y) );
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
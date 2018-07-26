namespace Adapter.Coding.Execise
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }
    
    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {
        private readonly Square _Square;

        public SquareToRectangleAdapter(Square square)
        {
            this._Square = square;
        }
        
        public int Width => _Square.Side;

        public int Height => _Square.Side;
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }
}
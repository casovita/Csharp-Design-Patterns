using System;
using Autofac;

namespace Bridge
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixel for cicle with radius {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer _Renderer;

        protected Shape(IRenderer renderer)
        {
            _Renderer = renderer ?? throw new ArgumentNullException(paramName: nameof(renderer));
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        private float _Radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this._Radius = radius;
        }

        public override void Draw()
        {
            _Renderer.RenderCircle(this._Radius);
        }

        public override void Resize(float factor)
        {
            this._Radius *= factor;
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
//            IRenderer renderer = new RasterRenderer();
//            var circle = new Circle(renderer, 5);
//            
//            circle.Draw();
//            circle.Resize(2);
//            circle.Draw();
            var cb = new ContainerBuilder();

            //every time that i im asking Irenderer i get VectorRenderer
            cb.RegisterType<VectorRenderer>().As<IRenderer>().SingleInstance();
            cb.Register((c, p) => new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0)));

            using (var c = cb.Build())
            {
                var circle = c.Resolve<Circle>(new PositionalParameter(0, 5.0f));
                circle.Draw();
                circle.Resize(2.0f);
                circle.Draw();
            }

            Console.ReadKey();
        }
    }
}
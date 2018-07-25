using System;
using System.Windows;

namespace Observer.WeakEventPattern
{
    // an event subscription can lead to a memory
    // leak if you hold on to it past the object's
    // lifetime

    // weak events help with this
    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            //button.Clicked+= ButtonOnClicked;
            WeakEventManager<Button, EventArgs>.AddHandler(button, "Clicked", ButtonOnClicked);
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked (Window handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            var btn = new Button();
            var window = new Window(btn);
            var weakReference = new WeakReference(window);

            btn.Fire();

            Console.WriteLine("Setting window to null");
            window = null;

            FireGC();

            Console.WriteLine($"Is the window alive after GC? {weakReference.IsAlive}");

          //  Console.ReadKey();
        }

        private static void FireGC()
        {
            Console.WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("GC is done");
        }
    }
}
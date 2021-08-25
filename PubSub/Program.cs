using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher1 pub1 = new Publisher1();
            pub1.OnChange += Pub1_OnChange1;
            pub1.OnChange += () => Console.WriteLine("Subscriber 2"); 
            pub1.Raise();

            Publisher2 pub2 = new Publisher2();
            pub2.OnChange += Pub2_OnChange1;
            pub2.OnChange += (sender, e) => Console.WriteLine($"Subscriber lambda: {e.Value}");
            pub2.Raise(123);
            pub2.Raise(987);

            Console.ReadKey();
        }

        private static void Pub2_OnChange1(object sender, MyEventArgs e)
        {
            Console.WriteLine($"Subscriber : {e.Value} ");
        }

        private static void Pub1_OnChange2()
        {
            Console.WriteLine("Subscriber 2");
        }

        private static void Pub1_OnChange1()
        {
            Console.WriteLine("Subscriber 1");
        }
    }

    class MyEventArgs : EventArgs
    {
        public int Value { get; set; }

    }

    class Publisher2
    {
        public event EventHandler<MyEventArgs> OnChange = delegate { };
        public void Raise(int v)
        {
            OnChange(this, new MyEventArgs() { Value=v });
        }
    }

    class Publisher1
    {
        public event Action OnChange = delegate { };

        public void Raise()
        {
            //invoke OnChange action delegate
            OnChange();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample
{
    class StockDummySimulator : IEnumerable<Stock>
    {
        private Random rnd = new Random();
        private string[] names = { "APL", "GOG", "IBM" };

        public IEnumerator<Stock> GetEnumerator()
        {
            Console.WriteLine("start iterator");
            for (int i = 0; i < 10; i++)
            {
                string n = names[rnd.Next(0, 3)];
                double v = rnd.Next(1, 101) + rnd.NextDouble();
                yield return new Stock(n, v);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Stock
    {
        public string Name;
        public double Value;
        public Stock(string name, double value)
        {
            Name = name; Value = value;
        }
    }
}

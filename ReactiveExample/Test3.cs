using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactiveExample
{
    static class Test3
    {
        public static void Run()
        {

            IObservable<Stock> source = Observable.Create<Stock>(
                observer =>
                {
                    Random rnd = new Random();
                    string[] names = { "APL", "GOG", "IBM" };
                    new Thread(()=> {
                        int i = 10;
                        while (i>0)
                        {
                            string n = names[rnd.Next(0, 3)];
                            double v = rnd.Next(1, 101) + rnd.NextDouble();
                            observer.OnNext(new Stock(n, v));
                            Thread.Sleep(500);
                            i--;
                        }
                        observer.OnCompleted();
                    }).Start();
                    return Disposable.Empty;
                }

                );

            IDisposable subscriber = source.Subscribe(
                x => Console.WriteLine($"On next: {x.Name} - {x.Value}"), // on next delegate
                ex => Console.WriteLine($"On error: {ex.Message}"), // on error delegate
                () => Console.WriteLine("On complete") // on complete delegate
            );
            Console.ReadKey();
            subscriber.Dispose();
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

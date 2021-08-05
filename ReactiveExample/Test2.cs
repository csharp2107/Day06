using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExample
{
    static class Test2
    {
        public static void Run()
        {
            //IObservable<int> source = Observable.Range(1, 10);
            IEnumerable<int> elements = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IObservable<int> source = elements.ToObservable();

            IObserver<int> observer = Observer.Create<int>(
                x => Console.WriteLine($"On next: {x}"), // on next delegate
                ex => Console.WriteLine($"On error: {ex.Message}"), // on error delegate
                () => Console.WriteLine("On complete") // on complete delegate
            );
            var subscriber = source.Subscribe(observer);
            Console.ReadKey();
            subscriber.Dispose();
        }
    }
}

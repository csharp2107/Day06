using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExample
{
    static class Test1
    {
        public static void Run()
        {
            IObservable<int> source = Observable.Range(1, 10);
            IDisposable subscriber = source.Subscribe(
                x => Console.WriteLine($"On next: {x}"), // on next delegate
                ex => Console.WriteLine($"On error: {ex.Message}"), // on error delegate
                () => Console.WriteLine("On complete") // on complete delegate
            );
            Console.ReadKey();
            subscriber.Dispose();
        }
    }
}

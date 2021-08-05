using ObserverExample.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample
{
    static class Simulator1
    {
        public static void Run()
        {
            // message pusblisher
            var observableStock = new Observable<Stock>();

            // observer for IBM
            IbmStockObserver ibmObserver = new IbmStockObserver();
            //observableStock.Register(ibmObserver);
            observableStock.Subscribe(ibmObserver);
            observableStock.Subscribe(ibmObserver);

            AppleStockObserver aplObserver = new AppleStockObserver();
            //observableStock.Register(aplObserver);
            observableStock.Unsubscribe(aplObserver);
            observableStock.Subscribe(aplObserver);

            StockDummySimulator stocksValues = new StockDummySimulator();
            foreach (var item in stocksValues)
            {
                Console.WriteLine($"STOCK GENERATOR: {item.Name} - {item.Value}");
                observableStock.Subject = item;
            }
            Console.ReadKey();
        }
    }
}

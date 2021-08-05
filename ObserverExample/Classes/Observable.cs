using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample.Classes
{
    class Observable<T>
    {
        private List<IObserver<T>> observers = new List<IObserver<T>>();
        private T subject;

        public T Subject {
            get => subject; 
            set
            {
                subject = value;
                Notify();
            }
        }

        private void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(subject);
            }
        }

        public void Register(IObserver<T> observer)
        {
            observers.Add(observer);
        }

        public void Unregister(IObserver<T> observer)
        {
            observers.Remove(observer);
        }

        public void Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        public void Unsubscribe(IObserver<T> observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }


    }
}

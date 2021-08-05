using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverExample.Classes
{
    interface IObserver<T>
    {
        void Update(T data);
    }
}

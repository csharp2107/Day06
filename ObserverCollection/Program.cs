using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeList empList = new EmployeeList();
            empList.CollectionChanged += EmpList_CollectionChanged;
            empList.Add(new Employee() { Name = "Peter" });
            //empList.RemoveAt(1);
            empList.Insert(0, new Employee() { Name = "John" });

            var result = empList.GetEmpByNameAndManager("E", true);
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.IsManager}");
            }
        }

        private static void EmpList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine(e.Action);
        }
    }
}

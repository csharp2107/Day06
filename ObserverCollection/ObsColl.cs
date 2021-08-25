using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverCollection
{
    class Employee
    {
        public String Name { get; set; }
        public bool? IsManager { get; set; } 
        public double? Salary { get; set; }
        public DateTime? StartAt { get; set; }
    }

    class EmployeeList : ObservableCollection<Employee>
    {
        public EmployeeList()
        {
            this.Add(new Employee() { Name="John"  }  );
            this.Add(new Employee() { Name = "Elvis", Salary=99999.99, IsManager=true });
            this.Add(new Employee() { Name = "Eleonora", Salary = 99999.99, IsManager = false });
            this.Add(new Employee() { Name = "Emil", Salary = 49999.99, IsManager = true });
        }

        public IEnumerable<Employee> GetEmpByNameAndManager(string name, bool? isManager)
        {
            var res = this.Where(x =>
               x.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase) &&
               x.IsManager == isManager).AsEnumerable<Employee>();
            return res;
        }
    }
}

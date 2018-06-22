using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRef
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}"
        }
    }

    class EmployeeList
    {
        Employee[] employee = new Employee[3];
        public EmployeeList()
        {
            employee[0] = new Employee { Id = 1, Name = "Vova" };
            employee[1] = new Employee { Id = 2, Name = "Ivan" };
            employee[2] = new Employee { Id = 3, Name = "Denis" };
        }
        Employee emp = null;
        public ref Employee SearchEmployeeByName(string name)
        {
            for (int i = 0; i < employee.Length; i++)
            {
                if (employee[i].Name == name)
                {
                    return ref employee[i];
                }
            }

            return ref emp;
        }

        public void Show()
        {
            for (int i = 0; i < employee.Length; i++)
            {
                Console.WriteLine(employee[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeList emp = new EmployeeList();
            
        }
    }
}

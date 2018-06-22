using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public Employee()
        {
            Id = Guid.NewGuid();
        }
    }
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            Database.SetInitializer(new EmployeeInicializer());
        }

        public DbSet<Employee> Employees { get; set; } 
    }

    public class EmployeeInicializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.Employees.Add(new Employee { Name = "Max", Salary = 100000 });
            context.Employees.Add(new Employee { Name = "Max", Salary = 100000 });

            context.Employees.Add(new Employee { Name = "Max", Salary = 100000 });

            context.SaveChanges();
        }
    }
}

using System;
using System.Linq;

namespace PrimaryAdded
{
    class Program
    {
        static void Main(string[] args)
        {
            using(AppContext db = new AppContext())
            {
                db.Customers.Add(new Customer { Id = 2, Age = 18, Name = "Max" });
                db.SaveChanges();

                foreach (var item in from c in db.Customers.ToList()
                                     select c)
                {
                    Console.WriteLine($"{item.Id}. {item.Name} {item.Age} ");
                }
            }
        }
    }
}

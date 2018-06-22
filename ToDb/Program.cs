using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Model1 m = new Model1())
            {
                List<Address> list = m.Address.ToList();

                IEnumerable<Address> query = from item in list
                            where item.AddressID % 2 == 0
                            orderby item.AddressID descending
                            select item;

                            
                foreach (var item in query)
                {
                    Console.WriteLine($"{item.AddressID} {item.AddressLine1} ");
                }
        }
        }
    }
}

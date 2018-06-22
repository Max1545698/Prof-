using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ToStringMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid g = new Guid("00000000-0000-0000-0000-000000000001");
            Guid g1 = new Guid("00000000-0000-0000-0000-000000000002");

            DateTime d = DateTime.Now;
            Console.WriteLine(d.ToString("G",new CultureInfo("ru-RU")));
            Console.WriteLine(g);
            Console.WriteLine(g1);
            CultureInfo c = new CultureInfo("en-EN");
            int a = 10;
            Console.WriteLine(a.ToString(c));
        }
    }
}

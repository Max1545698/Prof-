using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyGeneric
{
    using DateTimeList = System.Collections.Generic.List<System.DateTime>;
    class Program
    {
        static void Main(string[] args)
        {
            bool same = typeof(DateTimeList) == typeof(List<DateTime>);
            Console.WriteLine(same);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericInter
{
    class Program
    {
        public static void Method(IEnumerable<object> a)
        {
            IEnumerator<object> z = a.GetEnumerator();

            while (z.MoveNext())
            {
                Console.Write(z.Current);
            }
            z.Reset();
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            List<string> a = new List<string>
            {
                "Hello", " World", "!"
            };

            Method(a);

        }
    }
}

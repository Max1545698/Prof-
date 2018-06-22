using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder("Hello");
            Console.WriteLine(s.MaxCapacity);
            Console.WriteLine(s.Capacity);
            s.Length = 3;
            Console.WriteLine(s.ToString());
            Console.WriteLine(s[1]);
            s = s.Append(true);
            Console.WriteLine(s);
            s.Insert(1, "Hello");
            Console.WriteLine(s);
            s.AppendFormat("Hello World", new object());
            Console.WriteLine(s);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {1}", "Jeffrey", "Richter").Replace(" ", "-");

            string str = sb.ToString().ToUpper();

            sb.Length = 0;
            sb.Append(str).Insert(8, "Marc-");
            str = sb.ToString();
            Console.WriteLine(str);
        }
    }
}

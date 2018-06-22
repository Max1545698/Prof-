using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    public class Program : MarshalByRefObject
    {
        public void Method()
        {
            Console.WriteLine("~~~~~");
        }
       public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
        }
    }
}

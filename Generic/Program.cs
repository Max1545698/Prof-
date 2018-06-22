using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    delegate int MyDel(int a);
    class Program
    {
        
        static int Method(int a)
        {
            return a * 2;
        }
        static int Method1(int z)
        {
            return z * 3;
        }
        static void Main(string[] args)
        {
            List<int> m = new List<int>();
            MyDel d = new MyDel(Method);
            MyDel d1 = new MyDel(Method1);
            MyDel d2 = new MyDel(Method);
            MyDel dd;
            dd = d2 + d + d1;
            int result = dd(2);
            Console.WriteLine(result);
        }
    }
}

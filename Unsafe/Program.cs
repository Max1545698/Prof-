using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unsafe
{
    class MyClass
    {
        unsafe public void UnsafeMethod(int *a)
        {
            *a *= *a;
            int *z = a;
            //*z = 1000;
            *z += 10;
           
        }
    }


    class Program
    {
        unsafe static void Main(string[] args)
        {
            int a = 10;
            new MyClass().UnsafeMethod(&a);
            Console.WriteLine(a);
            Console.WriteLine(Math.Tan(1.2));
        }
    }
}

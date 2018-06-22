using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullAndGenerics
{
    class A<T>
    {
        public void Method(T t)
        {
            if(t == null)
            {
                Console.WriteLine("t == null");
            }
            if(t != null)
            {
                Console.WriteLine("t != null");
            }
        }
    }
    class B {}

    class Program
    {
        public static void Met<T, B>(T t, B b) where T : class where B : class
        {
            if(t == b)
            {
                Console.WriteLine("t == b");
            }
        }
        static void Main(string[] args)
        {

            A<int> a = new A<int>();
            a.Method(10);
        }
    }
}

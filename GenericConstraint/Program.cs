using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericConstraint
{
    class A
    {
        public virtual void Method<T1, T2>(T1 t1, T2 t2) where T1 : class where T2 : struct
        {

        }
    }

    class B : A
    {
        public override void Method<T10, T20>(T10 t1, T20 t2)
        {
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            b.Method("Hello", 10);
        }
    }
}

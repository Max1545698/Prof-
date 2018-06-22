using System;
using System.Collections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Prj
{
    interface A
    {
        event Action A;
    }
   
    class Program
    {

        void Method(string a = "text", int b = 3) { }
        static void Main(string[] args)
        {

            List<int> list = new List<int>() { 1, 2, 3 };

            var x = list.GroupBy(i => { Console.Write(i); return i; });

            var y = list.ToLookup(i => { Console.Write(i); return i; });
        }
    }
}

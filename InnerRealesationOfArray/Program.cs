using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerRealesationOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Array a;
            a = new string[0];
            Console.WriteLine(a.GetType());

            a = Array.CreateInstance(typeof(string),new int[] { 1 }, new int[] { 0 });
            Console.WriteLine(a.GetType());

            a = Array.CreateInstance(typeof(string), new int[] { 0 }, new int[] { 1 });
            Console.WriteLine(a.GetType());

            Console.WriteLine();

            a = new string[0, 0];
            Console.WriteLine(a.GetType());

            a = Array.CreateInstance(typeof(string), new int[] { 0, 0 }, new int[] { 0, 0 });
            Console.WriteLine(a.GetType());

            a = Array.CreateInstance(typeof(string), new int[] { 0, 0 }, new int[] { 1, 1 });
            Console.WriteLine(a.GetType());
            
        }
    }
}

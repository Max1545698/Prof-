using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompare
{
    class MyComparer<T> : Comparer<T>
    {
        public override int Compare(T x, T y)
        {
            return y.GetHashCode() - x.GetHashCode();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int x = 22;
            int y = 20;
            Console.WriteLine(x.GetHashCode());
            Console.WriteLine(y.GetHashCode());
            MyComparer<int> compare = new MyComparer<int>();
            Console.WriteLine(compare.Compare(x, y));
        }
    }
}

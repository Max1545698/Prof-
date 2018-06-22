using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList
{
    class DescendingComparer<T> : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();
            return (comparer.Compare(x, y));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            SortedList<string, int> sortedList = new SortedList<string, int>(new DescendingComparer<string>())
            {
                ["A"] = 1,
                ["B"] = 2,
                ["C"] = 3
            };

            foreach (KeyValuePair<string, int> d in sortedList)
            {
                Console.WriteLine(d.Key + " " + d.Value);
            }
        }
    }
}

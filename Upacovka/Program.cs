using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upacovka
{
    class Program
    {
        static void Main(string[] args)
        {
            var sort = new SortedList(new DescendingComparer());

            sort["First"] = "1";
            sort["First"] = "1-st";
            sort["Second"] = "2";
            sort["Third"] = "3";
            sort["Fourth"] = "4";

            foreach (DictionaryEntry item in sort)
            {
                Console.WriteLine(item.Key + " --- " + item.Value);
            };
        }


    }
    class DescendingComparer : IComparer
    {
        CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();
        public int Compare(object x, object y)
        {
            int result = comparer.Compare(y, x);
            return result;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary[0] = "Hello";
            dictionary[0] = "World";
            foreach (var item in dictionary)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }
}

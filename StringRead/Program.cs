using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringRead
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello all!" + Environment.NewLine + "This is a multi-line \ntext string";

            var reader = new StringReader(s);

            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                Console.WriteLine(line);
            }
        }
    }
}

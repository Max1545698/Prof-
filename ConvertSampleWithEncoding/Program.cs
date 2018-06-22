using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertSampleWithEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            byte[] bytes = new byte[10];
            r.NextBytes(bytes);

            Console.WriteLine(BitConverter.ToString(bytes));

            string s = Convert.ToBase64String(bytes);
            Console.WriteLine(s);

            bytes = Convert.FromBase64String(s);
            Console.WriteLine(BitConverter.ToString(bytes));

        }
    }
}

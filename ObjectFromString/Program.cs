using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ObjectFromString
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(" 123", NumberStyles.AllowLeadingWhite, null);
            Console.WriteLine(x);
            x = int.Parse("   FF", NumberStyles.HexNumber, null);
            Console.WriteLine(x);
        }
    }
}

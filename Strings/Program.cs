using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {

            string s1 = "Strasse";
            string s2 = "Straße";
            bool eq;
            eq = string.Compare(s1, s2, StringComparison.Ordinal) == 0;
            Console.WriteLine("Ordinal comparission: {0} {2} {1}", s1, s2, eq ? "==" : "!=");
            CultureInfo ci = new CultureInfo("de-DE");

            eq = string.Compare(s1, s2, true, ci) == 0;
            Console.WriteLine("Cultural comparison: {0} {2} {1}", s1, s2, eq ? "==" : "!=");

            Console.WriteLine(((IConvertible)10).ToDouble(null) + 0.3);

            StringComparer s = StringComparer.Create(ci, true);
            Console.WriteLine(s.Compare(10, 10));
        }
    }
}

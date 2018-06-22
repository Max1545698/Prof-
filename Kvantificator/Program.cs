using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Kvantificator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Regex.Match("color", "colou?r").Success);
            Console.WriteLine(Regex.Match("colour", "colou?r").Success);
            Console.WriteLine(Regex.Match("clouur","colou?r").Success);

            Console.WriteLine(new string('-', 40));

            Match m = Regex.Match("any colour you like", "colou?r");
            Console.WriteLine(m.Index);
            Console.WriteLine(m.Length);
            Console.WriteLine(m.Value);
            Console.WriteLine(m.ToString());

            Console.WriteLine(new string('-', 40));

            Match m1 = Regex.Match("One color? There are two colours in my head!",
                @"colou?rs?");
            Match m2 = m1.NextMatch();
            Console.WriteLine(m1);
            Console.WriteLine(m2);

            foreach (Match item in Regex.Matches("One color? There are two colours in my head!", @"colou?rs?"))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 40));

            MatchCollection matchCollection = Regex.Matches("Jenny, Jen, Jennifer", "Jen(ny|nifer)?");
            foreach (Match item in matchCollection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 40));

            Regex r = new Regex(@"sausages?", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
            Console.WriteLine(r.Match("sausage"));
            Console.WriteLine(r.Match("SAUSAGES"));

            Console.WriteLine(new string('-', 40));

            Console.WriteLine(Regex.Match("what?", @"what\?"));
            Console.WriteLine(Regex.Match("what", @"what?"));

            Console.WriteLine(new string('-', 40));

            Console.WriteLine(Regex.Escape(@"?"));
            Console.WriteLine(Regex.Unescape(@"\?"));

            Console.WriteLine(Regex.Match("\\", "\\\\"));
            Console.WriteLine(Regex.IsMatch("hello world", @"hello world"));
        }
    }
}

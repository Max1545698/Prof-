using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace Intern
{
    class Program
    {
        private static int NumTimesWordAppearsInterns(string word, string[] worlist)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            int count = 0;
            word = string.Intern(word);
            for (int wordnum = 0; wordnum < worlist.Length; wordnum++)
            {
                if (ReferenceEquals(word, worlist[wordnum]))
                {
                    count++;
                }
            }
            s.Stop();
            Console.WriteLine("Ticks " + s.Elapsed.Ticks);
            return count;
        }
        private static int NumTimesWordAppearsEquals(string word, string[] worlist)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            int count = 0;
           
            for (int wordnum = 0; wordnum < worlist.Length; wordnum++)
            {
                if (word.Equals(worlist[wordnum],StringComparison.Ordinal))
                {
                    count++;
                }
            }
            s.Stop();
            Console.WriteLine("Ticks " + s.Elapsed.Ticks);
            return count;
        }
        static void Main(string[] args)
        {
            string s = "Hello";
            string[] list = new string[] { "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference","Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference", "Hello", "Goodbye", "Hello", "df", "dfdf", "Hello", "Reference" };
            Console.WriteLine("Element count " + NumTimesWordAppearsEquals(s, list));
            Console.WriteLine("Element count " + NumTimesWordAppearsInterns(s, list));
        }
    }

}

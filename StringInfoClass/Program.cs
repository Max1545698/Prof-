using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StringInfoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            string s = "a\u0304\u0308bc\u0327";
            SubstringByTextElements(s);
            TextElementEnumerator text = StringInfo.GetTextElementEnumerator(s);
            
            while (text.MoveNext())
            {
                Console.WriteLine(text.GetTextElement());
                Console.WriteLine(text.ElementIndex);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(text.Current);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        private static void SubstringByTextElements(string s)
        {
            string output = string.Empty;
            StringInfo si = new StringInfo(s);
            for (int i = 0; i < si.LengthInTextElements; i++)
            {
                output += string.Format("Text element {0} is '{1}' {2}", i, si.SubstringByTextElements(i, 1), Environment.NewLine);
            }

            MessageBox.Show(output, "Result of ParceCombiningCharacters");
        }
    }
}

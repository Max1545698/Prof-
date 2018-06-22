using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stackalloc
{
    class Program
    {
        static void Main(string[] args)
        {
            StacallocDemo();
            InlineArrayDemo();
        }

        private static void StacallocDemo()
        {
            unsafe
            {
                const int width = 20;
                char* pc = stackalloc char[width];

                string s = "Max Rozhok";

                for(int index = 0; index < width; index++)
                {
                    pc[width - index - 1] = (index < s.Length) ? s[index] : '.';
                }
                Console.WriteLine(new string(pc, 0, width));
            }
        }

        private static void InlineArrayDemo()
        {
            unsafe
            {
                CharArray ca;
                int widthInBytes = sizeof(CharArray);
                int width = widthInBytes / 2;

                string s = "Max Rozhok";

                for(int index = 0; index < width; index++)
                {
                    ca.Characters[width - index - 1] = (index < s.Length) ? s[index] : '.';
                }
                Console.WriteLine(new string(ca.Characters,0,width));
            }
        }

        
    }
    internal unsafe struct CharArray
    {
        public fixed char Characters[20];
    }
}

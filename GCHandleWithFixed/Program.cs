using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCHandleWithFixed
{
    class Program
    {
        unsafe public static void Go()
        {
            for(int i = 0; i < 10_000; i++)
            {
                new Object();
            }
            IntPtr originalMeoryAddress;
            byte[] bytes = new byte[1000];

            fixed(byte* pbytes = bytes)
            {
                originalMeoryAddress = (IntPtr)pbytes;
            }
            GC.Collect();

            fixed(byte* pbytes = bytes)
            {
                Console.WriteLine("The byte[] did{0} move during the GC",
                    (originalMeoryAddress == (IntPtr)pbytes)? " not" : null);
            }
        }
        static void Main(string[] args)
        {
            Go();
        }
    }
}

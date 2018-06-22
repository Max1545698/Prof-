using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.InteropServices;

namespace SecureStringSample
{
    public static class Program
    {
        private unsafe static void DisplaySecureString(SecureString ss)
        {
            char* pc = null;
            try
            {
                (pc) = (char*)Marshal.SecureStringToCoTaskMemUnicode(ss);

                for(int index = 0; pc[index] != 0; index++)
                {
                    Console.Write(pc[index]);
                }
                Console.WriteLine();
            }
            finally
            {
                if (pc != null)
                    Marshal.ZeroFreeCoTaskMemUnicode((IntPtr)pc);
            }
        }
        static void Main(string[] args)
        {
            using (SecureString ss = new SecureString())
            {
                Console.WriteLine("Please enter password: ");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                Console.WriteLine(ss);

                Console.WriteLine();

                DisplaySecureString(ss);


            }
        }
    }
}

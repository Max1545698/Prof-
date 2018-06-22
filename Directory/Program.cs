using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Directory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] directory = System.IO.Directory.GetLogicalDrives();

            foreach (var item in directory)
            {
                Console.WriteLine(item);
            }

            var info = new DirectoryInfo(@".");
            System.IO.Directory.Delete(@"A:\A");

        }
    }
}

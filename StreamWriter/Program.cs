using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"A:\DataFile.txt", FileMode.Create);
            System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
            sw.Write("Hi there");
            sw.Dispose();
            File.Delete(@"A:\DataFile.txt");

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GCOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] byteToWrite = new byte[] { 65, 66, 67, 68, 69 };

            using (FileStream fs = new FileStream("Temp.txt", FileMode.Create))
            {
                fs.Write(byteToWrite, 0, byteToWrite.Length);
            }

            File.Delete("Temp.txt");
        }
    }
}

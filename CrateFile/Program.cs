using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrateFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new FileStream("Text.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            for (int i = 0; i < 256; i++)
            {
                stream.WriteByte((byte)i);
            }
   
            Console.WriteLine(stream.Position);

            stream.Position = 0;

            for(int i = 0; i < 256; i++)
            {
                Console.WriteLine(" " + stream.ReadByte());
            }
            stream.Close();
        }
    }
}

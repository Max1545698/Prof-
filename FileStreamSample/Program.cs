using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Stream s = new FileStream("text.txt", FileMode.Create))
            {
                
                Console.WriteLine(s.CanRead);
                Console.WriteLine(s.CanWrite);
                Console.WriteLine(s.CanSeek);
                s.WriteByte(101);
                s.WriteByte(102);

                byte[] block = { 1, 2, 3, 4, 5 };
                s.Write(block, 0, block.Length);
                Console.WriteLine(s.Length);
                Console.WriteLine(s.Position);
                s.Position = 0;
                Console.WriteLine(s.ReadByte());
                Console.WriteLine(s.ReadByte());
                Console.WriteLine(s.Read(block,0,block.Length));
                Console.WriteLine(s.Read(block,0,block.Length));
            }
        }
    }
}

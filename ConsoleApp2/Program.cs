using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream s = File.Open(@"A:/(Видео урок) 001_Знакомство с языком C#.mp4",FileMode.Open);
            Console.WriteLine(s.Length);
            int z;
            List<byte> h = new List<byte>();
            while((z = s.ReadByte()) != -1)
            {
                h.Add((byte)z);
            }
            
            FileStream f = File.Create(@"A:/vide0.mp4");
            f.Write(h.ToArray(), 0, h.Count);
        }
    }
}

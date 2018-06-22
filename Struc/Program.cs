using System;
using System.IO;
using System.Threading.Tasks;

namespace Struc
{
    class Program
    {
        static void Main(string[] args)
        {            
            var file = new FileInfo(@"A:\Text.txt");

            StreamWriter writer = file.CreateText();
            writer.WriteLine("First string of text...");
            writer.WriteLine("Second string of text...");

            writer.Write(writer.NewLine);

            writer.WriteLine("Third string are numbers:");

            for (int i = 0; i < 10; i++)
            {
                writer.Write(i + " ");
            }

            writer.Write(writer.NewLine);

            writer.Close();

           // file.Delete();

            Console.WriteLine("File Text.txt was created and put text into");
        }
    }
}

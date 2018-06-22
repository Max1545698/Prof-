using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOpenRead
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = File.OpenWrite(@"A:\MyText.txt");

            var writer = new StreamWriter(file);

            writer.WriteLine("This is a men's world");
            writer.WriteLine("It's a great song");
            writer.WriteLine("I want be a millioner");

            writer.Close();

            file = File.OpenRead(@"A:\MyText.txt");

            var reader = new StreamReader(file);

            Console.WriteLine(reader.ReadToEnd());
            reader.Close();

            File.Delete(@"A:\MyText.txt");
            
        }
    }
}

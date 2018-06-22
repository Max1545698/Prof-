using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write Name of text file");
            Console.Write(@"A:\");
            string path = @"A:\" + Console.ReadLine() + ".txt";

            Console.WriteLine("What you want find");
            string find = Console.ReadLine();

            using (FileStream file = File.Open(path, FileMode.Open, FileAccess.ReadWrite))
            {
                StreamReader reader = new StreamReader(file);

                while (!reader.EndOfStream)
                {
                    
                    string line = reader.ReadLine();

                    if (line != null && line.Contains(find))
                    {
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (find == line.Substring(i, find.Length))
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write(find);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine(line.Substring(i + find.Length));
                                break;
                            }
                            Console.Write(line[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine(line);
                    }
                }
                reader.Close();
            }
        }
    }
}

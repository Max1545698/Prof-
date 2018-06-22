using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProj
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Jeff", "Kristin", "Aidan", "Grant" };
            char charToFind = 'a';
            names = Array.FindAll(names, name =>  name.IndexOf(charToFind) >= 0 );
            names = Array.ConvertAll(names, name => name.ToUpper());
            Array.ForEach(names, Console.WriteLine);
        }
    }
}

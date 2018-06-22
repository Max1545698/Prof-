using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream("data.sdf",FileMode.Create);
        }
    }
}

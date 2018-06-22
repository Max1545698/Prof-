using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folder_99
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Directory.CreateDirectory($@"A:\Doc\Folder{i}");
            }
            for (int i = 0; i < 100; i++)
            {
                Directory.CreateDirectory($@"A:\Doc\Folder{i}");
            }
        }
    }
}

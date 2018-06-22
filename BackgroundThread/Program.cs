using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundThread
{
   
    class Program
    {
       
        static void Main(string[] args)
        {
            Thread t = new Thread(Worker);

            t.IsBackground = true;

            t.Start();

            Console.WriteLine("Returning from Main");
        }

        private static void Worker()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Returning from Worker");
        }
    }
}

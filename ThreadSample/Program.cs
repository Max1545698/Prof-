using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: starting a dedicated thread to do an asynchronous operation");
            Thread dedicatedThread = new Thread(ComputeBoundOp);
            dedicatedThread.Start(5);

            Console.WriteLine("Main thread: Doing other work here...");
            //Thread.Sleep(10000);

            dedicatedThread.Join();
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }

        private static void ComputeBoundOp(object state)
        {
            Thread.Sleep(5000);
            Console.WriteLine("In CompeteBoundOp: state={0}", state);
        }
    }
}

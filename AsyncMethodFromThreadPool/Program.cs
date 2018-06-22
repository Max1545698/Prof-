using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncMethodFromThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            Console.WriteLine("Main thread: Doing other work here...");
            Thread.Sleep(10000);
            Console.WriteLine("Hit<Enter> to end this program");
            Console.ReadLine();
        }

        private static void ComputeBoundOp(object state)
        {
            Console.WriteLine($"In ComputeBoundOp: state={state}");
            Thread.Sleep(1000);
            ThreadPool.QueueUserWorkItem((x) => Console.WriteLine($"state={x}"), 10);
        }
    }
}

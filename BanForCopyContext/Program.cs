using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BanForCopyContext
{
    class Program
    {
        static void Main(string[] args)
        {
            CallContext.LogicalSetData("Name", "Max");

            ThreadPool.QueueUserWorkItem(state => Console.WriteLine($"Name={CallContext.LogicalGetData("Name")}"));

            ExecutionContext.SuppressFlow();

            Thread.Sleep(1000);
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine($"Name={CallContext.LogicalGetData("Name")}"));

            Thread.Sleep(1000);
            ExecutionContext.RestoreFlow();

            ThreadPool.QueueUserWorkItem(state => Console.WriteLine($"Name={CallContext.LogicalGetData("Name")}"));

            Console.ReadLine();
        }
    }
}

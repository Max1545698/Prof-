using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CancellationDemoSample
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource(2000);
            cts.Token.Register(() => Console.WriteLine("Canceled 1"));
            cts.Token.Register(() => Console.WriteLine("Canceled 2"));
            ThreadPool.QueueUserWorkItem(x => Count(cts.Token, 100));
            Console.WriteLine("Press enter to break the counting");
            Console.ReadKey();
            cts.Cancel();
            Console.ReadKey();

        }

        private static void Count(CancellationToken token, int countTo)
        {
            for (int i = 0; i < countTo; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Counting break");
                    break;
                }
                Console.WriteLine(i);
                Thread.Sleep(200);
            }
            Console.WriteLine("Counting Finish");
        }

    }
}

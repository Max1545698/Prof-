using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedTokenSource
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts1 = new CancellationTokenSource();
            cts1.Token.Register(() => Console.WriteLine("cts1 canceled"));

            CancellationTokenSource cts2 = new CancellationTokenSource();
            cts2.Token.Register(() => Console.WriteLine("cts2 canceled"));

            CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
            linkedCts.Token.Register(() => Console.WriteLine("linkedCts canceled"));

            cts2.Cancel();

            Console.WriteLine($"cts1 canceled={cts1.IsCancellationRequested}," +
                $" cts2 canceled={cts2.IsCancellationRequested}, linkedCts={linkedCts.IsCancellationRequested} ");
        }
    }
}

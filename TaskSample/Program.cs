using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample
{
    class Program
    {
        private static int Sum(CancellationToken cancellation, int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                cancellation.ThrowIfCancellationRequested();
                checked { sum += n; }
            }
            return sum;
        }
        private static int Sum(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                checked { sum += n; }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            Task<int> task = new Task<int>(x => Sum((int)x), 10);
            task.Start();
            task.Wait();
            Console.WriteLine($"The sum is: {task.Result}");


            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Token.Register(() => Console.WriteLine("CancellationTokenSource canceled"));

            Task<int> t = new Task<int>(() => Sum(cts.Token, 100), cts.Token);

            t.Start();
            cts.Cancel();

            try
            {
                Console.WriteLine($"The sum is: {t.Result}");
            }
            catch(AggregateException ex)
            {
                Console.WriteLine("!!!!!!");
                ex.Handle(e => e is OperationCanceledException);
            }

            Console.WriteLine("Sum was canceled");
        }
    }
}

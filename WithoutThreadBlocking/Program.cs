using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WithoutThreadBlocking
{
    class Program
    {
        public static event Action D
        {
            add
            {
               if (value.GetInvocationList() == null)
                {

                } 
            }
            remove
            {

            }
        }
        private static int Sum(CancellationToken ct, int n)
        {
            int sum = 0;

            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();
                checked { sum += n; }
            }
            return sum;
        }
        static void Main(string[] args)
        {
            D += () => Console.WriteLine();

            Task<int> t = Task.Run(() => Sum(CancellationToken.None, 10000000));
            
            Task cwt = t.ContinueWith(task => Console.WriteLine($"The sum is: /*task.Result*/"),TaskContinuationOptions.OnlyOnFaulted);

           // Console.WriteLine(t.Result);
            Console.WriteLine(cwt);


        }
    }
}

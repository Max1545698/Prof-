using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelSample
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 1000; i++) DoWork(i);

            
            Parallel.For(0, 1000, i => DoWork1(i));

            int[] collection = { 1,2,3,4,5,6,7,8,9};
            foreach (var item in collection)
            {
                DoWork(item);
            }

            Task task = new Task(() => Console.WriteLine("Hello World!"));
            task.ContinueWith(t1 => Console.WriteLine("Hello World1!"),TaskContinuationOptions.NotOnFaulted);
            task.Start(TaskScheduler.Default);

            CancellationTokenSource t = new CancellationTokenSource();

            ParallelOptions p = new ParallelOptions();
            p.CancellationToken = t.Token;
            p.CancellationToken.Register(() => Console.WriteLine("Hello World"));

           ParallelLoopResult loopState = Parallel.ForEach(collection, p,  i => DoWork(i));

            Method1();
            Method2();
            Method3();

            Parallel.Invoke(
                () => Method1(),
                () => Method2(),
                () => Method3());
        }

        private static void DoWork1(int i)
        {
            Console.WriteLine("DoWork1");
        }

        private static void Method1()
        {
            Console.WriteLine("Method1");
        }

        private static void Method2()
        {
            Console.WriteLine("Method2");
        }

        private static void Method3()
        {
            Console.WriteLine("Method3");
        }

        private static void DoWork(int i)
        {
            Console.WriteLine("DoWork");
        }
    }
}

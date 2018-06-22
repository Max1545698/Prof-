using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskFactorySample
{
    class Program
    {
        static int Sum(CancellationToken cts, int sum)
        {
            int result = 0;
            for (; sum > 0; sum--)
            {
                cts.ThrowIfCancellationRequested();
                checked { result += sum; }
            }
            return result;
        }


        static void Main(string[] args)
        {
            Task parent = new Task(() =>
            {
                var cts = new CancellationTokenSource();
                var tf = new TaskFactory<int>(cts.Token,
                    TaskCreationOptions.AttachedToParent,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);

                var childTask = new[]
                {
                    tf.StartNew(() => Sum(cts.Token, 10000)),
                    tf.StartNew(() => Sum(cts.Token, 20000)),
                    tf.StartNew(() => Sum(cts.Token, int.MaxValue))
                };

                for (int i = 0; i < childTask.Length; i++)
                {
                    childTask[i].ContinueWith(
                        t => cts.Cancel(), TaskContinuationOptions.OnlyOnFaulted);
                }

                tf.ContinueWhenAll(childTask, completedTask => completedTask.Where(
                     t => !t.IsFaulted && !t.IsCanceled).Max(t => t.Result),
                    CancellationToken.None)
                    .ContinueWith(t => Console.WriteLine($"The maximum is" +
                    $"{t.Result}"));
            });

            parent.ContinueWith(p =>
            {
                StringBuilder sb = new StringBuilder(
                    $"The following exception(s) occurred: {Environment.NewLine}");

                foreach (var e in p.Exception.Flatten().InnerExceptions)
                {
                    sb.AppendLine(" " + e.GetType().ToString());
                    Console.WriteLine(sb.ToString());
                }
            }, TaskContinuationOptions.OnlyOnFaulted);

            parent.Start();
            Thread.Sleep(1000);
            //parent.Wait();
        }
    }
}

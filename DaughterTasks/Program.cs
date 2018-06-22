using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaughterTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => Console.WriteLine("Alpha")).
                ContinueWith((a) => Console.WriteLine("Betta")).
                ContinueWith((a) => Console.WriteLine("Gamma")).
                Wait();



            Task<int[]> parent = new Task<int[]>(() =>
            {
                var results = new int[3];

                new Task(() => results[0] = Sum(100),
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = Sum(200),
                    TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = Sum(300),
                    TaskCreationOptions.AttachedToParent).Start();

                return results;
            });


            var cwt = parent.ContinueWith(
                parentTask => Array.ForEach(parentTask.Result, Console.WriteLine));

            parent.Start();
           // parent.Wait();
            cwt.Wait();

        }

        private static int Sum(int v)
        {
            int result = 0;
            for (; v > 0; v--)
            {
                checked { result += v; }
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeSample
{
    internal static class TimerDemo
    {
        private static Timer s_timer;

        static void Main(string[] args)
        {
            Console.WriteLine("Checking status evry 2 seconds");

            s_timer = new Timer(Status, null, Timeout.Infinite, Timeout.Infinite);

            s_timer.Change(0, Timeout.Infinite);

            Console.ReadLine();
        }

        private static void Status(object state)
        {
            Console.WriteLine($"In Status at {DateTime.Now}");
            Thread.Sleep(1000);
            s_timer.Change(2000,Timeout.Infinite);
        }
    }
}

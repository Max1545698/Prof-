using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class A
    {
        public void Firstly()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Firstly");
            }
        }

        public void Secondary()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(new string(' ', 10) + "Secondary");
            }
        }
    }
    class Program
    {
        public delegate void DisplayHandler();
        static void Main(string[] args)
        {
            DisplayHandler handler = new DisplayHandler(Display);
           // handler += new A().Firstly;
            IAsyncResult resultObj = handler.BeginInvoke(null, null);
            Console.WriteLine("Продолжается работа метода Main");
            //  int result = handler.EndInvoke(resultObj);

            // Console.WriteLine("Результат равен {0}", result);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();

            Console.WriteLine(resultObj.IsCompleted);
        }

        static void Display()
        {
            Console.WriteLine("Начинается работа метода Display....");

            int result = 0;
            for (int i = 1; i < 10; i++)
            {
                result += i * i;
            }
          //  Thread.Sleep(3000);
            Console.WriteLine("Завершается работа метода Display....");
           // return result;
        }
    }
}

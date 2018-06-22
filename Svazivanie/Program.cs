using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Svazivanie
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Потоки на делегатах
            Action a = () => { while (true) { Thread.Sleep(200); Console.Write("*"); } };
            //a += () => { while (true) { Thread.Sleep(200); Console.Write("+"); } };
            Action b = () => { while (true) { Thread.Sleep(200); Console.Write("!"); } };

            a.BeginInvoke(null, null);
            b.BeginInvoke(null, null);
            #endregion


            #region Позднее связывание в цикле
            Action m = null;

            for (int i = 0; i < 3; i++)
            {
                m += () => { Console.WriteLine(i); };
            }
            m();
            #endregion

            Console.WriteLine(new string('-', 2));

            #region Позднее связывание в развернутом виде
            Action n = null;

            int counter = 0;
            n += () => { Console.WriteLine(counter); };

            counter = 1;
            n += () => { Console.WriteLine(counter); };

            counter = 2;
            n += () => { Console.WriteLine(counter); };

            counter = 3;

            n.Invoke();
            #endregion
            Console.ReadKey();
        }
    }
}

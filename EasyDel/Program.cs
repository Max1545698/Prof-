using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyDel
{
    internal sealed class AClass
    {
        public static void UsingLocalVariablesInTheCallcackCode(int numToDo)
        {
            int[] square = new int[numToDo];
            AutoResetEvent done = new AutoResetEvent(false);
            
            for(int i = 0; i < square.Length; i++)
            {
                ThreadPool.QueueUserWorkItem(
                obj =>
                {
                    int num = (int)obj;
                    square[num] = num * num;
                    if (Interlocked.Decrement(ref numToDo) == 0)
                    {
                        done.Set();
                    }
                },
                i);
            }
            done.WaitOne();
            for (int i = 0; i < square.Length; i++)
            {
                Console.WriteLine($"Index {i}, Square={square[i]}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AClass.UsingLocalVariablesInTheCallcackCode(10);  
        }
    }
}

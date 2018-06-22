using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static int Factorial(int factorial)
        {
            if (factorial < 0) throw new ArgumentException("Factorial can't be either then 0");
            else if (factorial == 0) return 1;
            else return factorial * Factorial(factorial - 1);

        }
        static int[] GetFactorialArr(int[] arr)
        {
            int[] returnsArr = arr;
            for (int i = 0; i < arr.Length; i++)
            {
                returnsArr[i] = Factorial(returnsArr[i]);
            }
            return returnsArr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Write a length of array");
            int arrLen = int.Parse(Console.ReadLine());
            int[] array = new int[arrLen];
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write($"array[{i}] = ");
                array[i] = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            array = GetFactorialArr(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"array[{i}] = {array[i]}");
            }

        }
    }
}

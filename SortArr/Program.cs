using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArr
{
    class Program
    {
        static void RandomArr(int[] arr)
        {
            Random r = new Random();
            
            for(int i =0; i < arr.Length; i++)
            {
                arr[i] = r.Next(-100, 100);
            }
        }
        static void Sort(int[] arr, bool ascending = true)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (ascending)
                    {
                        if (arr[i] < arr[j])
                        {
                            int buf = arr[j];
                            arr[j] = arr[i];
                            arr[i] = buf;
                        }
                    }
                    else
                    {
                        if (arr[i] > arr[j])
                        {
                            int buf = arr[j];
                            arr[j] = arr[i];
                            arr[i] = buf;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] arr = new int[20];
            RandomArr(arr);
           
            Console.WriteLine("Before Sort:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            }
            Console.WriteLine(new string('-', 50));
            Sort(arr,false);
            Console.WriteLine("After sort ascending");
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"arr[{i}] = {arr[i]}");
            }
        }
    }
}

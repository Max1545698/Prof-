using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeDll
{
    public static class Algo
    {
        public static void SortArr(int[] arr, bool ascending = true)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (ascending)
                    {
                        if (arr[i] > arr[j])
                        {
                            int buff = arr[i];
                            arr[i] = arr[j];
                            arr[j] = buff;
                        }
                    }
                    else
                    {
                        if (arr[i] < arr[j])
                        {
                            int buff = arr[i];
                            arr[i] = arr[j];
                            arr[j] = buff;
                        }
                    }
                }
            }
        }
    }
}

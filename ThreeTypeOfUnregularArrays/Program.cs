using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeTypeOfUnregularArrays
{
    class Program
    {
        private const int c_numElements = 10000;
        static void Main(string[] args)
        {   
            int[,] a2Dim = new int[c_numElements, c_numElements];

            int[][] aJagged = new int[c_numElements][];
            for (int x = 0; x < c_numElements; x++)
            {
                aJagged[x] = new int[c_numElements];
            }
            Console.WriteLine(Safe2DimArrayAccess(a2Dim));

            Console.WriteLine(SafeJaggedArrayAccess(aJagged));

            Console.WriteLine(Unsafe2DimArrayAccess(a2Dim));
        }

        

        private static int Safe2DimArrayAccess(int[,] a)
        {
            int sum = 0;
            for (int i = 0; i < c_numElements; i++)
            {
                for(int j = 0; j < c_numElements; j++)
                {
                    sum += a[i, j];
                }
            }
            return sum;
        }

        private static int SafeJaggedArrayAccess(int[][] a)
        {
            int sum = 0;
            for(int i = 0; i < c_numElements; i++)
            {
                for(int j = 0; j < c_numElements; j++)
                {
                    sum += a[i][j];
                }
            }
            return sum;
        }

        private static unsafe int Unsafe2DimArrayAccess(int[,] a)
        {
            int sum = 0;
            fixed (int* pi = a)
            {
                for(int i = 0; i < c_numElements; i++)
                {
                    int baseOfDim = i * c_numElements;
                    for(int j = 0; j < c_numElements; j++)
                    {
                        sum += pi[baseOfDim + j];
                    }
                }
            }
            return sum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenInIlDasm
{
    internal sealed class Type1 { }
    internal sealed class Type2 { }

    class Program
    {
        private static async Task<Type1> Method1Async() { return await Task.Run(() => new Type1()); }
        private static async Task<Type2> Method2Async() { return await Task.Run(() => new Type2()); }

        private static async Task<string> MyMethodAsync(int argument)
        {
            int local = argument;
            try
            {
                Type1 result1 = await Method1Async();
                for (int x = 0; x < 3; x++)
                {
                    Type2 result2 = await Method2Async();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            return "Done";
        }

        static void Main(string[] args)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null_ComparisionTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write x: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write("Write y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.Write("Write z: ");
            double z = Convert.ToDouble(Console.ReadLine());

            double sum;

            double z1 = x + Math.Pow(y,2) + Math.Pow(z, 3);
            double z2 = 1 + Math.Pow((x + y + z), 2);
            double z3 = Math.Sin(z1 / z2);
            sum = z3 * Math.Sqrt(Math.Abs(x + y + z));
            Console.WriteLine("Sum = " + sum);
        }
    }
}

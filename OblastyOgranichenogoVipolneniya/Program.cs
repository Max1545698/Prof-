using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OblastyOgranichenogoVipolneniya
{
    public class Type2
    {
        static Type2()
        {
            Console.WriteLine("Type2's static ctor called");
            //throw new DivideByZeroException();
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static void M() { }
    }
    class Program
    {
        private static void Demo2()
        {
            RuntimeHelpers.PrepareConstrainedRegions();
            //Console.WriteLine("Hello");
            try
            {
                Console.WriteLine("In try");
            }
            finally
            {
                Type2.M();
            }
        }
        static void Main(string[] args)
        {
            Demo2();
            //Garanted code
           //RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup((x) => { }, (x, y) => { }, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcLib;

namespace CalcLibUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc c = new Calc();
            double result = c.Div(10, 0);
            Console.WriteLine(result);
        }
    }
}

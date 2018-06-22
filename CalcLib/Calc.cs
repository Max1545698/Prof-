using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLib
{
    public class Calc
    {
        /// <summary>
        /// add first summand to second summand
        /// </summary>
        /// <param name="x">fist summand</param>
        /// <param name="y">second summand</param>
        /// <returns>sum of two summands</returns>
        public double Add(double x, double y)
        {
            checked
            {
                return x + y;
            }
        }
        public double Sub(double x, double y)
        {
            checked
            {
                return x - y;
            }
        }
        public int Div(int x, int y)
        {
            checked
            {
                try
                {
                    return x / y;
                }
                catch (DivideByZeroException ex)
                {
                    Debug.WriteLine(ex.Message);
                    Debug.WriteLine(ex.StackTrace);
                    throw;
                }
            }
        }
        public double Mul(double x, double y)
        {
            checked
            {
                return x * y;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericList
{
    class Point
    {
        int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator ++(Point p)
        {
            return new Point(++p.x, ++p.y);
        }
        public override string ToString()
        {
            return $"x = {x} y = {y}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(10, 20);
            p++;
            Console.WriteLine(p);
        }
    }
}

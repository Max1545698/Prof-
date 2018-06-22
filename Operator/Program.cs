using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator
{
    class Point
    {
        int x;
        int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"X = {x} Y = {y}";
        }

        public static Point operator +(Point p1, Point p2)
        {
            if (p1 != null && p2 != null)
                return new Point(p1.x + p2.x, p1.y + p2.y);
            else throw new NullReferenceException();
        }

        public static explicit operator Point(int a)
        {
            return new Point(a, a);
        }
        //public static implicit operator Int32(Point p)
        //{
        //    return p.x + p.y;
        //}

    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(3, 3);
            Point p2 = new Point(3, 3);
            Point p3 = p1 + p2;
            p3 += p1;
            Point p4 = (Point)10;
            Console.WriteLine(p3);
            Console.WriteLine(p4);

        }
    }
}

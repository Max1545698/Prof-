using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOperators
{
    public sealed class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator +(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        public static Point operator -(Point point1, Point point2)
        {
            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }

        public static Point operator *(Point point1, Point point2)
        {
            return new Point(point1.X * point2.X, point1.Y * point2.Y);
        }

        public static Point operator /(Point point1, Point point2)
        {
            if (point2.X == 0 || point2.Y == 0)
            {
                throw new DivideByZeroException("point2 property x or y have value 0");
            }
            return new Point(point1.X / point2.X, point1.Y / point2.Y);
        }

        public static explicit operator Int32(Point point)
        {
            return point.X + point.Y;
        }



        public override string ToString()
        {
            return $"X = {X}, Y = {Y}";
        }

    }
    class Program
    {

        static void Main(string[] args)
        {
            Point p = new Point(2, 0);
            Console.WriteLine(p + p);
            Console.WriteLine(p - p);
            Console.WriteLine(p * p);
            try
            {
                Console.WriteLine(p / p);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            int x = (int)p;
            Console.WriteLine(x);
            Console.WriteLine(p);
        }
    }
}

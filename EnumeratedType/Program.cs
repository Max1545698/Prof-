using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratedType
{
    internal enum Color : byte 
    {
        White,
        Red,
        Green,
        Blue,
        Orange
    }
    class Program
    {
        static void Main(string[] args)
        {
            Color c = Color.Blue;
            Console.WriteLine(c);
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.ToString("G"));
            Console.WriteLine(c.ToString("D"));
            Console.WriteLine(c.ToString("X"));
            Console.WriteLine(Enum.Format(typeof(Color), (byte)3, "G"));
            Console.WriteLine(new string('-', 50));
            // ---------------------------------------------------------
            Color[] colors = (Color[])Enum.GetValues(typeof(Color)); //Program.GetEnumValues<Color>();
            Console.WriteLine("Number of symbols defined: " + colors.Length);
            Console.WriteLine("Values\tSymbol\n-----\t------");
            foreach (Color item in colors)
            {
                Console.WriteLine("{0,5:D}\t{0:G}", item);
            }
             
            Color cc;
            Enum.TryParse<Color>("23", false, out cc);
            Console.WriteLine("-----" + cc);

        }
        public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }
    }


}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitVector
{
    class Program
    {
        static void Main(string[] args)
        {
            BitVector32.Section firsSection = BitVector32.CreateSection(10);
            BitVector32.Section secondSection = BitVector32.CreateSection(50, firsSection);
            BitVector32.Section thirdSection = BitVector32.CreateSection(500, secondSection);
            BitVector32.Section fourthSection = BitVector32.CreateSection(500, thirdSection);

            var packedBits = new BitVector32(0);

            packedBits[firsSection] = 10;
            packedBits[secondSection] = 50;
            packedBits[thirdSection] = 500;
            packedBits[fourthSection] = 500;

            Console.WriteLine(packedBits);

            Console.WriteLine(packedBits.Data);
        }
    }
}

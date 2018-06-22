using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncodingDecoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hi there.";

            Encoding encodingUTF8 = Encoding.UTF8;

            byte[] encodedBytes = encodingUTF8.GetBytes(s);

            Console.WriteLine("Encoded bytes: " + BitConverter.ToString(encodedBytes));


            string decodedString = encodingUTF8.GetString(encodedBytes);

            Console.WriteLine("Decoded string: " + decodedString);

            ASCIIEncoding aSCII = (ASCIIEncoding)Encoding.ASCII;
            Console.WriteLine(aSCII.ToString());
        }
    }
}

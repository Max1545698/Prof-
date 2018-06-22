using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace Format
{
    internal sealed class BoldInt32s : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            string s;
            IFormattable formattable = arg as IFormattable;

            if (formattable == null)
                s = arg.ToString();
            else
                s = formattable.ToString(format, new CultureInfo("en-US")); //formatProvider 
            if (arg.GetType() == typeof(int))
                return "<B>" + s + "</B>";
            return s;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            return Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }
    }
    public static class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(new BoldInt32s(), "{0} {1} {2:M}", "Jeff", 123, DateTime.Now);
            Console.WriteLine(sb);
        }
    }
}

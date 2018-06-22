using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateInstanceReflection
{
   // internal sealed class Dictionary<TKey, TValue> { }
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Dictionary<,>);
            Console.WriteLine(type.IsGenericTypeDefinition);
            Type closedType = type.MakeGenericType(new Type[] { typeof(int), typeof(string) });

            object o = Activator.CreateInstance(closedType);
            Console.WriteLine(o.GetType());
        }
    }
}

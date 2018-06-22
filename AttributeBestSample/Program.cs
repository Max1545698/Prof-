#define VERIFY

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;


namespace AttributeBestSample
{
    [Conditional("TEST")]
    [Conditional("VERIFY")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class CondAttribute : Attribute { }

    [Cond]
    public sealed class Program
    {
        public static void Main(string[] args)
        {
           IEnumerable<ConditionalAttribute> a = typeof(CondAttribute).GetCustomAttributes<ConditionalAttribute>();

            foreach (var item in a)
            {
                Console.WriteLine(item.GetType() + " " + item.ConditionString);
            }
            Console.WriteLine("CondAttribute is {0}applied to Program type.",
                Attribute.IsDefined(typeof(Program), typeof(CondAttribute)) ? "" : "not ");
        }
    }
}

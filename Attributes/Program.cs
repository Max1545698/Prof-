using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class MyAttribute : Attribute
    {
        public int A { get; set; }
        public string Str { get; set; }
        public MyAttribute(int a, string str)
        {
            A = a;
            Str = str;
        }
    }

    [My(2,"World")]
    [My(10,"Hello")]
    internal class MyClass
    {

    }

    internal class MyDerivedClass : MyClass
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDerivedClass d = new MyDerivedClass();

            MyAttribute[] obj = (MyAttribute[])d.GetType().GetCustomAttributes(typeof(MyAttribute),true);

            Console.WriteLine(obj[0].A + " " + obj[0].Str + " " + obj[0].TypeId);

            for(int i = 0; i < obj.Length; i++)
            {
                Console.WriteLine(obj[i]);
            }

            Console.WriteLine((d.GetType().IsDefined(typeof(MyAttribute), true)));
        }
    }
}

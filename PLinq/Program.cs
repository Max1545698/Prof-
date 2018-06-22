using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PLinq
{
    class Program
    {
        private static void ObsoleteMethods(Assembly assembly)
        {
            var query = from type in assembly.GetExportedTypes().AsParallel()
                        from method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                        let obsoleteAttrType = typeof(ObsoleteAttribute)
                        where Attribute.IsDefined(method, obsoleteAttrType)
                        orderby type.FullName
                        let obsolateAttrObj = (ObsoleteAttribute)Attribute.GetCustomAttribute(method, obsoleteAttrType)
                        select $"Type={type.FullName}\nMethod={method.ToString()},\nMessage={obsolateAttrObj.Message}";


            query.ForAll(Console.WriteLine);
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}
        }
        static void Main(string[] args)
        {
            Assembly a = Assembly.GetAssembly(typeof(ArrayList));
            ObsoleteMethods(a);

        }
    }
}

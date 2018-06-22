using System;
using System.Collections.Generic;
using System.Reflection;

namespace MemberInfoSample
{
    class Program
    {
        public static void Show(int ident, string format, params object[] args)
        {
            Console.WriteLine(new string('-', 3 * ident) + format, args);
        }
        static void Main(string[] args)
        {
           
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly a in assemblies)
            {
                Show(0, $"Assembly: {a}");

                foreach (Type t in a.GetTypes())
                {
                    Show(1, $"Type: {t}");

                    foreach (MemberInfo mi in t.GetTypeInfo().DeclaredMembers)
                    {
                        
                        string typeName = string.Empty;
                        if (mi is Type) typeName = "(Nested) Type";
                        if (mi is FieldInfo) typeName = "FieldInfo";
                        if (mi is MethodInfo) typeName = "MethodInfo";
                        if (mi is ConstructorInfo) typeName = "ConstructorInfo";
                        if (mi is PropertyInfo) typeName = "PropertyInfo";
                        if (mi is EventInfo) typeName = "EventInfo";
                        Show(2, $"{typeName}: {mi}");
                    }
                }
            }
        }
    }
}

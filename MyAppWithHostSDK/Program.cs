using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wintellect.HostSDK;

namespace MyAppWithHostSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            string AddInDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var AddInAssemblies = Directory.EnumerateFiles(AddInDir, "*.dll");

            var AddInTypes =
                from file in AddInAssemblies
                let assembly = Assembly.Load(file)
                from t in assembly.ExportedTypes
                where t.IsClass && typeof(IAddIn).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo())
                select t;

            foreach (Type t in AddInTypes)
            {
                IAddIn ai = (IAddIn)Activator.CreateInstance(t);
                Console.WriteLine(ai.DoSomething(5));
            }
        }
    }
}

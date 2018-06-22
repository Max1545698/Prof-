using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SomeDll;


namespace LoadDomain
{
    class Program
    {
        private static Assembly ResolveEventHandle(object sender, ResolveEventArgs args)
        {
            string dllName = new AssemblyName(args.Name).Name + ".dll";

            var assem = Assembly.GetExecutingAssembly();
            string resourceName = assem.GetManifestResourceNames().FirstOrDefault((x) => x.EndsWith(dllName));

            if (resourceName == null) return null;
            
            using(var stream = assem.GetManifestResourceStream(resourceName))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
        static void Main(string[] args)
        {
            System.Activator.CreateInstance(new object().GetType());
            string dataAssembly = "System.Data, version=4.0.0.0, " +
                "culture=neutral, PublicKeyToken=b77a5c561934e089";
            LoadAssemAndShowPublicTypes(dataAssembly);
        }

        private static void LoadAssemAndShowPublicTypes(string assemId)
        {
            Assembly a = Assembly.Load(assemId);
            foreach (Type t in a.ExportedTypes)
            {
                Console.WriteLine(t.FullName);
            }
        }

        private static void SomeMethod(object o)
        {
            Type type = o.GetType();
            TypeInfo typeInfo = type.GetTypeInfo();

            if(o.GetType() == typeof(FileInfo)) { }
            if(o.GetType() == typeof(DirectoryInfo)) { }
        }
    }
}

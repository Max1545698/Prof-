using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RuntimeMethodHandleSample
{
    public sealed class Program
    {
        private const BindingFlags c_bf = BindingFlags.FlattenHierarchy |
            BindingFlags.Instance |
            BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        public static void Main()
        {
            Show("Before doing anything");

            List<MethodBase> methodInfos = new List<MethodBase>();

            foreach (Type t in typeof(object).Assembly.GetExportedTypes())
            {
                if (t.IsGenericTypeDefinition) continue;
                MethodBase[] mb = t.GetMethods(c_bf);
                methodInfos.AddRange(mb);
            }

            Console.WriteLine("# of methods={0:N0}",methodInfos.Count);
            Show("After building cache of MethodInfo objects");

            List<RuntimeMethodHandle> methodHandles =
                methodInfos.ConvertAll<RuntimeMethodHandle>(mb => mb.MethodHandle);

            Show("Holding MethodInfo and RuntimeMethodHandle cache");
            GC.KeepAlive(methodInfos);

            methodInfos = null;
            Show("After freeing MethodInfo objects");

            methodInfos = methodHandles.ConvertAll<MethodBase>(
                rmh => MethodBase.GetMethodFromHandle(rmh));
            Show("Size of heap after re-creating MethodInfo objects");
            GC.KeepAlive(methodHandles);
            GC.KeepAlive(methodInfos);

            methodHandles = null;
            methodInfos = null;
            Show("After freeing MethodInfos and RuntimeMethodHandles");
        }

        private static void Show(string v)
        {
            Console.WriteLine(v);
        }
    }
}

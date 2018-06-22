using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalWeakTableSample
{
    internal static class ConditionalWeakTableDemo
    {
        static void Main(string[] args)
        {
            Object o = new Object().GCWatch("my Object created at " + DateTime.Now);
            GC.Collect();
            GC.KeepAlive(o);
            o = null;
            GC.Collect();
            Console.ReadLine();
        }
    }

    internal static class GCWatcher
    {
        private readonly static ConditionalWeakTable<Object, NotifyWhenGCd<string>> s_cwt =
            new ConditionalWeakTable<Object, NotifyWhenGCd<string>>();
        private sealed class NotifyWhenGCd<T>
        {
            private readonly T m_value;
            internal NotifyWhenGCd(T value) { m_value = value; }
            public override string ToString()
            {
                return m_value.ToString();
            }
            ~NotifyWhenGCd() { Console.WriteLine("GC'd: " + m_value); }
        }
        public static T GCWatch<T>(this T @object, string tag) where T : class
        {
            s_cwt.Add(@object, new NotifyWhenGCd<string>(tag));
            return @object;
        }

    }

}

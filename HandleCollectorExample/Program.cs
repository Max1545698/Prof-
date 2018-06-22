using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace HandleCollectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryPressureDemo(0);
            MemoryPressureDemo(10 * 1024 * 1024);

            HandleCollectorDemo();
        }

        private static void MemoryPressureDemo(int size)
        {
            Console.WriteLine();
            Console.WriteLine("MemorypressureDemo, size = {0}", size);
            for (int count = 0; count < 15; count++)
            {
                new BigNativeResource(size);
            }
            GC.Collect();
        }


        private sealed class BigNativeResource
        {
            private int m_size;

            public BigNativeResource(int size)
            {
                m_size = size;
                if (m_size > 0) GC.AddMemoryPressure(m_size);
                Console.WriteLine("BigNativeResource create.");
            }
            ~BigNativeResource()
            {
                if (m_size > 0) GC.RemoveMemoryPressure(m_size);
                Console.WriteLine("BigNativeResource destroy.");
            }
        }

        private static void HandleCollectorDemo()
        {
            Console.WriteLine();
            Console.WriteLine("HandleCollectorDemo");
            for (int count = 0; count < 10; count++)
            {
                new LimitedResource();
            }
            GC.Collect();
        }

        private sealed class LimitedResource
        {
            private static HandleCollector s_hc = new HandleCollector("LimitedResource", 2);
            public LimitedResource()
            {
                s_hc.Add();
                Console.WriteLine($"LimitedREsource create. Count={s_hc.Count}");
            }

            ~LimitedResource()
            {
                s_hc.Remove();
                Console.WriteLine($"LimitedResource destroy. Count={s_hc.Count}");
            }
        }

    }
}

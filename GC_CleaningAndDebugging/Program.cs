
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GC_CleaningAndDebugging
{
    class Program
    {
        private static void LowLatencyDemo()
        {
            GCLatencyMode oldMode = GCSettings.LatencyMode;
            System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;
                //Here doing code
            }
            finally
            {
                GCSettings.LatencyMode = oldMode;
            }
        }
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerCallBack,null,0,2000);

            Console.ReadLine();
            t.Dispose();
        }

        static void TimerCallBack(object o)
        {
            Console.WriteLine("In TimerCallback: " + DateTime.Now);
            GC.Collect();
            GCSettings.LatencyMode = GCLatencyMode.Batch;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GCNotification
{
    public static class GCNotificat
    {
        private static Action<int> s_gcDone = null;

        public static event Action<int> GCDone
        {
            add
            {
                if (s_gcDone == null)
                {
                    new GenObject(0);
                    new GenObject(2);
                }
                s_gcDone += value;
            }
            remove
            {
                s_gcDone -= value;
            }
        }

        private sealed class GenObject
        {
            private int m_generation;
            public GenObject(int generation)
            {
                m_generation = generation;
            }
            ~GenObject()
            {
                Volatile.Read(ref s_gcDone)?.Invoke(m_generation);


                if ((s_gcDone != null)
                     && !AppDomain.CurrentDomain.IsFinalizingForUnload()
                     && !Environment.HasShutdownStarted)
                {
                    if (m_generation == 0) new GenObject(0);
                    else GC.ReRegisterForFinalize(this);
                }
                else { }
            }



        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

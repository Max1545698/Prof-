using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSet
{
    public sealed class EventKey : Object { }

    public sealed class EventSet
    {
        private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();


        public void Add(EventKey eventKey, Delegate handler)
        {
            lock (m_events)
            {
                Delegate d;
                m_events.TryGetValue(eventKey, out d);
                m_events[eventKey] = Delegate.Combine(d, handler);
            }
        }

        public void Remove(EventKey eventKey, Delegate handler)
        {
            lock (m_events)
            {
                Delegate d;
                if(m_events.TryGetValue(eventKey, out d))
                {
                    d = Delegate.Remove(d, handler);
                    if (d != null)
                        m_events.Remove(eventKey);
                }
            }
        }

        public void Raise(EventKey eventKey, object sender, EventArgs e)
        {
            Delegate d;
            lock (m_events)
            {
                m_events.TryGetValue(eventKey, out d);
            }
            if(d!= null)
            {
                d.DynamicInvoke(new object[]{ sender,e});
            }
        }
    }

    public class FooEventArgs : EventArgs { }

    class Program
    {
        public static void Method()
        {
            Console.WriteLine("Hello World");
        }
        static void Main(string[] args)
        {
            EventSet s = new EventSet();
            s.Add(new EventKey(), new Action(Method));
            s.Raise(new EventKey(), "My", new EventArgs());
            s.Remove(new EventKey(), new Action(Method));
        }
    }
}

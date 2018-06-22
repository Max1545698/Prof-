using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsWithHandler
{
    class MyEventArgs : EventArgs
    {
        public MyEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}";
        }

    }
    class A
    {
        EventHandler<MyEventArgs> myEvent = null;
        public event EventHandler<MyEventArgs> MyEvent
        {
            add
            {
                myEvent += value;
            }
            remove
            {
                myEvent -= value;
            }
        }

        public void Invoke(object sender, MyEventArgs e)
        {
            myEvent.Invoke(sender,e);
        }
    }
    class Program
    {
        static void Method(object sender, MyEventArgs e)
        {
            Console.WriteLine("Events message");
            Console.WriteLine(e.ToString());

        }
        static void Main(string[] args)
        {
            A a = new A();
            a.MyEvent += Method;
            MyEventArgs m = new MyEventArgs(10, 13);
            a.Invoke(null, m);
            
        }
    }
}

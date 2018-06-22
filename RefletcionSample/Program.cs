using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace RefletcionSample
{
    internal sealed class SomeType
    {
        private int m_someField;
        public SomeType(ref int x)
        {
            x *= 2;
        }
        public override string ToString()
        {
            return m_someField.ToString();
        }
        public int SomeProp
        {
            get { return m_someField; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("value");
                m_someField = value;
            }
        }
        public event EventHandler SomeEvent;

        private void NoCompilerWarnings() { SomeEvent.ToString(); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(SomeType);
            BindToMemberThenInvokeTheMember(t);
            Console.WriteLine();

        }

        private static void BindToMemberThenInvokeTheMember(Type t)
        {
            Console.WriteLine("BindToMemberThenInvokeTheMember");

            Type ctorAgrument = Type.GetType("System.Int32&");
            // or typeof(int).MakeByRefType();
            ConstructorInfo ctor = t.GetTypeInfo().DeclaredConstructors.First(
                c => c.GetParameters()[0].ParameterType == ctorAgrument);
            object[] args = new object[] { 12 };
            Console.WriteLine("x before constructor called: " + args[0]);
            object obj = ctor.Invoke(args);
            Console.WriteLine("Type: " + obj.GetType());
            Console.WriteLine("x after constructor returns: " + args[0]);

            FieldInfo fi = obj.GetType().GetTypeInfo().GetDeclaredField("m_someField");
            fi.SetValue(obj, 33);
            Console.WriteLine("someField: " + fi.GetValue(obj));

            MethodInfo mi = obj.GetType().GetTypeInfo().GetDeclaredMethod("ToString");
            string s = (string)mi.Invoke(obj, null);
            Console.WriteLine("ToString: " + s);

            PropertyInfo pi = obj.GetType().GetTypeInfo().GetDeclaredProperty("SomeProp");
            try
            {
                pi.SetValue(obj, 0, null);
            }
            catch(TargetInvocationException ex)
            {
                if (ex.InnerException.GetType() != typeof(ArgumentOutOfRangeException)) throw;
                Console.WriteLine("Propert set catch.");
            }
            pi.SetValue(obj, 2, null);
            Console.WriteLine("SomeProp: " + pi.GetValue(obj,null));

            EventInfo ei = obj.GetType().GetTypeInfo().GetDeclaredEvent("SomeEvent");
            EventHandler eh = new EventHandler(EventCallback);
            ei.AddEventHandler(obj, eh);
            ei.RemoveEventHandler(obj, eh);
        }
        private static void EventCallback(object sender, EventArgs e) { }

      
    }
}

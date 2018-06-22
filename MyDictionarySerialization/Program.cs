using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionarySerialization
{
    [Serializable]
    class Base
    {
        protected string m_name = "Max";
        public Base()
        {

        }
    }
    [Serializable]
    class Derived : Base, ISerializable
    {
        private DateTime m_date = DateTime.Now;
        public Derived()
        {

        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private Derived(SerializationInfo info, StreamingContext context)
        {
            Type baseType = this.GetType().BaseType;
            MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);

            for (int i = 0; i < mi.Length; i++)
            {
                FieldInfo fi = (FieldInfo)mi[i];
                fi.SetValue(this, info.GetValue(baseType.FullName + "+" + fi.Name, fi.FieldType));
            }

            //m_date = info.GetDateTime("Date");
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Data", m_date);

            Type baseType = this.GetType().BaseType;
            MemberInfo[] mi = FormatterServices.GetSerializableMembers(baseType, context);

            for (int i = 0; i < mi.Length; i++)
            {
                info.AddValue(baseType.FullName + "+" + mi[i].Name, ((FieldInfo)mi[i]).GetValue(this));
            }
        }

        public override string ToString()
        {
            return $"Name={m_name}, Date={m_date}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter b = new BinaryFormatter();
            using (FileStream m = File.Open("A:\\SomeMyText.txt", FileMode.OpenOrCreate))
            {
                

                b.Serialize(m, new Derived());
            }
            using (FileStream m = File.Open("A:\\SomeMyText.txt", FileMode.OpenOrCreate))
            {
                Derived d = (Derived)b.Deserialize(m);
                Console.WriteLine(d);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SerealizeDesirializeSingletonObject
{
    [Serializable]
    public sealed class Singleton : ISerializable
    {
        private static readonly Singleton theOneObject = new Singleton();

        public string Name = "Jeff";
        public DateTime Date = DateTime.Now;

        private Singleton() { }

        public static Singleton GetSingleton() { return theOneObject; }

       

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.SetType(typeof(SingletonSerializationHelper));
        }
        [Serializable]
        private sealed class SingletonSerializationHelper : IObjectReference
        {
            public object GetRealObject(StreamingContext context)
            {
                return Singleton.GetSingleton();
            }
        }

        public static void SingletonSerializationTest()
        {
            Singleton[] a1 = { Singleton.GetSingleton(), Singleton.GetSingleton() };
            Console.WriteLine("Do both elements refer to the same object? " + (a1[0] == a1[1]));

            using (var stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a1);
                stream.Position = 0;
                Singleton[] a2 = (Singleton[])formatter.Deserialize(stream);

                Console.WriteLine("Do both elements refer to the same object? " + (a2[0] == a2[1]));
                Console.WriteLine("Do all elements refer to the same object? " + (a1[0] == a2[0]));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.SingletonSerializationTest();
        }
    }
}

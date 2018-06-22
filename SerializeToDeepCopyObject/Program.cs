using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializeToDeepCopyObject
{
    [Serializable]
    internal class Circle
    {
        private double m_radius;

        [NonSerialized]
        private double m_area;

        public Circle(double radius, double area)
        {
            m_radius = radius;
            m_area = Math.PI * m_radius * m_radius;
        }
        
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            m_area = Math.PI * m_radius * m_radius;
        }
    }
    [Serializable]
    public class MyType
    {
        int x, y;
        [NonSerialized]
        int sum;

        public MyType(int x, int y)
        {
            this.x = x;
            this.y = y;
            sum = x + y;
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {

        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            sum = x + y;
        }
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            
        }
        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(10,0);
            Circle c1 = DeepClone(c) as Circle;

        }

        private static object DeepClone(object original)
        {
            using(MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Context = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Clone);
                formatter.Serialize(stream, original);
                stream.Position = 0;
                return formatter.Deserialize(stream);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationDeserializationSample
{
    internal static class QuickStart
    {
        public static void Main()
        {
            var objectGraph = new List<string>
            {
                "Jeff","Kristin","Aidan","Grant"
            };
 
            Stream stream = SerializeToMemory(objectGraph);
            
            stream.Position = 0;
            objectGraph = null;

            objectGraph = (List<string>)DeserializeFromMemory(stream);
            foreach (var s in objectGraph)
            {
                Console.WriteLine(s);
            }
        }
            
        private static MemoryStream SerializeToMemory(object objectGraph)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objectGraph);

            return stream;
        }

        private static object DeserializeFromMemory(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
    } 
   
}

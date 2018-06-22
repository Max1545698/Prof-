using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SerializationSurrogate
{
    internal sealed class UniversalToLocalTimeSerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Date", ((DateTime)obj).ToUniversalTime().ToString("u"));
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            return DateTime.ParseExact(info.GetString("Date"), "u", null).ToLocalTime();
        }
    }
    class Program
    {
        private static void SerializationSurrogateDemo()
        {
            using (var stream = new MemoryStream())
            {
                
                IFormatter formatter = new SoapFormatter();

                SurrogateSelector ss = new SurrogateSelector();

                ss.AddSurrogate(typeof(DateTime), formatter.Context, new UniversalToLocalTimeSerializationSurrogate());
                formatter.SurrogateSelector = ss;

                DateTime localTimeBeforeSerialize = DateTime.Now;
                formatter.Serialize(stream, localTimeBeforeSerialize);

                stream.Position = 0;
                Console.WriteLine(new StreamReader(stream).ReadToEnd());
                
                stream.Position = 0;
                DateTime localTimeAfterDeserialize = (DateTime)formatter.Deserialize(stream);

                Console.WriteLine("LocalTimeBeforeSerialize = {0}", localTimeBeforeSerialize);
                Console.WriteLine("LocalTimeAfterDeserialize = {0}", localTimeAfterDeserialize);
            }
        }
        static void Main(string[] args)
        {
            SerializationSurrogateDemo();
        }
    }
}

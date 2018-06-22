using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IfProgramIsDamaged
{
    class A
    {
        public void SerializeObjectGraph(FileStream fs, IFormatter formatter, object rootObj)
        {
            long beforeSerialization = fs.Position;

            try
            {
                formatter.Serialize(fs, rootObj);
            }
            catch
            {
                fs.Position = beforeSerialization;
                fs.SetLength(fs.Position);
                throw;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class SimpleClass
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(Property1);
            writer.Write(Property2);
        }

        public void Deserialize(BinaryReader reader)
        {
            if (reader.PeekChar() < 0)
                throw new Exception("Stream ended unexpectedly while deserializing.");

            Property1 = reader.ReadInt32();

            if (reader.PeekChar() < 0)
                throw new Exception("Stream ended unexpectedly while deserializing.");

            Property2 = reader.ReadString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class SimpleClass : ISerializable
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }

        public SimpleClass() { }

        protected SimpleClass(SerializationInfo info, StreamingContext context)
        {
            Property1 = info.GetInt32("Property1");
            Property2 = info.GetString("Property2");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Property1", Property1);
            info.AddValue("Property2", Property2);
        }
    }
}

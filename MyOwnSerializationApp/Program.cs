using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using Common;

var simpleClass = new SimpleClass { Property1 = 5, Property2 = "Test" };

BinaryFormatter formatter = new BinaryFormatter();
using (FileStream stream = new FileStream("output.dat", FileMode.OpenOrCreate))
{
    formatter.Serialize(stream, simpleClass);
    Console.WriteLine("Object serialized");
}

using (FileStream stream = new FileStream("output.dat", FileMode.Open))
{
    SimpleClass newSimpleClass = (SimpleClass)formatter.Deserialize(stream);
    Console.WriteLine("Object deserialized");
    Console.WriteLine("Property 1: " + newSimpleClass.Property1);
    Console.WriteLine("Property 2: " + newSimpleClass.Property2);
}
using Common;

var simpleClass = new SimpleClass ();

// Serialization
using (FileStream stream = new FileStream("output.dat", FileMode.Create))
using (BinaryWriter writer = new BinaryWriter(stream))
{
    simpleClass.Serialize(writer);
}

Console.WriteLine("Object serialized");

// Deserialization
SimpleClass newSimpleClass = new SimpleClass();
using (FileStream stream = new FileStream("output.dat", FileMode.Open))
using (BinaryReader reader = new BinaryReader(stream))
{
    newSimpleClass.Deserialize(reader);
}

Console.WriteLine("Object deserialized");
Console.WriteLine("Property 1: " + newSimpleClass.Property1);
Console.WriteLine("Property 2: " + newSimpleClass.Property2);
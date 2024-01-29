using Common;
using System.Runtime.Serialization.Formatters.Binary;

AppContext.SetSwitch("System.Runtime.Serialization.Formatters.BinaryFormatter.SurrogateSelector", true);
AppContext.SetSwitch("System.Runtime.Serialization.Formatters.AllowAnySerializableObject", true);

var department = new Department();

BinaryFormatter formatter = new BinaryFormatter();
using (FileStream fs = new FileStream("department.dat", FileMode.OpenOrCreate))
{
    formatter.Serialize(fs, department);
    Console.WriteLine("Object serialized");
}
using (FileStream fs = new FileStream("department.dat", FileMode.OpenOrCreate))
{
    Department newDepartment = (Department)formatter.Deserialize(fs);
    Console.WriteLine("Object deserialized");
    Console.WriteLine(newDepartment.DepartmentName);
}
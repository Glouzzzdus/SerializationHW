using Common;
using System.Xml.Serialization;

var department = new Department();
XmlSerializer formatter = new XmlSerializer(typeof(Department));
using (FileStream fs = new FileStream("department.xml", FileMode.OpenOrCreate))
{
    formatter.Serialize(fs, department);
    Console.WriteLine("Object serialized");
}
using (FileStream fs = new FileStream("department.xml", FileMode.OpenOrCreate))
{
    Department? newDepartment = (Department)formatter.Deserialize(fs);
    Console.WriteLine("Object deserialized");
    Console.WriteLine(newDepartment.DepartmentName);
}
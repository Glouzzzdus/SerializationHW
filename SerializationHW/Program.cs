using Common;
using System.Runtime.Serialization.Formatters.Binary;

var department = new Department
{
    DepartmentName = "Sales",
    Employees = new List<Employee> { new Employee { EmployeeName = "John Doe" }
}
};
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
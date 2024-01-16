using Common;
using Newtonsoft.Json;

var department = new Department
{
    DepartmentName = "Sales",
    Employees = new List<Employee> { new Employee { EmployeeName = "John Doe" }
}
};
string json = JsonConvert.SerializeObject(department);
File.WriteAllText("department.json", json);
Console.WriteLine("Object serialized");
string jsonFromFile = File.ReadAllText("department.json");
Department newDepartment = JsonConvert.DeserializeObject<Department>(jsonFromFile);
Console.WriteLine("Object deserialized");
Console.WriteLine(newDepartment.DepartmentName);
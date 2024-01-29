using Common;
using Newtonsoft.Json;

var department = new Department();
string json = JsonConvert.SerializeObject(department);
File.WriteAllText("department.json", json);
Console.WriteLine("Object serialized");
string jsonFromFile = File.ReadAllText("department.json");
Department? newDepartment = JsonConvert.DeserializeObject<Department>(jsonFromFile);
Console.WriteLine("Object deserialized");
Console.WriteLine(newDepartment.DepartmentName);
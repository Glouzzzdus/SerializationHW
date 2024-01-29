using System.IO;
using System.Text;
using Common;

class Program
{
    static void Main()
    {
        var department = new Department();

        var departmentClone = DeepClone(department);

        Console.WriteLine(department.DepartmentName);
        Console.WriteLine(department.Employees.First().EmployeeName);
        Console.WriteLine(departmentClone.DepartmentName);
        Console.WriteLine(departmentClone.Employees.First().EmployeeName);
    }

    private static T DeepClone<T>(T original)
        where T : ISerializable, new()
    {
        using var memoryStream = new MemoryStream();
        using (var writer = new BinaryWriter(memoryStream, Encoding.Default, leaveOpen: true))
        {
            original.Serialize(writer);
        }

        memoryStream.Position = 0;

        var clone = new T();
        using (var reader = new BinaryReader(memoryStream, Encoding.Default))
        {
            clone.Deserialize(reader);
        }

        return clone;
    }
}
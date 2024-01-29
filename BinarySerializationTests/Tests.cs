using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using Common;

[TestClass]
public class SerializationTests
{
    private string fileName = "test.dat";
    private Department? department;

    [TestMethod]
    public void TestBinarySerializationAndDeserialization()
    {
        // Init
        department = new Department
        {
            DepartmentName = "Sales",
            Employees = new List<Employee> { new Employee { EmployeeName = "John Doe" } }
        };

        // Serialization
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(fs))
        {
            department.Serialize(writer);
        }

        // Deserialization
        Department newDepartment = new Department();
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        using (BinaryReader reader = new BinaryReader(fs))
        {
            newDepartment.Deserialize(reader);
        }

        // Check
        Assert.AreEqual(department.DepartmentName, newDepartment.DepartmentName);
        if (department.Employees != null && department.Employees.Count > 0)
        {
            Assert.AreEqual(department.Employees[0].EmployeeName, newDepartment.Employees?[0].EmployeeName);
        }
    }

    [TestCleanup]
    public void TestCleanup()
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }
    }
}
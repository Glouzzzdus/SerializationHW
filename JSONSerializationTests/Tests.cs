using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace JSONSerializationTests
{
    [TestClass]
    public class DepartmentAppTests
    {
        private string fileName = "test.json";
        private Department? department;

        [TestMethod]
        public void TestJsonSerializationAndDeserialization()
        {
            // Init
            department = new Department
            {
                DepartmentName = "Sales",
                Employees = new List<Employee> { new Employee { EmployeeName = "John Doe" } }
            };

            // Serialization in JSON and recording
            string json = JsonConvert.SerializeObject(department);
            File.WriteAllText(fileName, json);

            // Reading JSON from file and deserialization
            string jsonFromFile = File.ReadAllText(fileName);
            Department? newDepartment = JsonConvert.DeserializeObject<Department>(jsonFromFile);

            // Checking
            Assert.AreEqual(department.DepartmentName, newDepartment.DepartmentName);
            if (department.Employees != null && department.Employees.Count > 0)
            {
                Assert.AreEqual(department.Employees[0].EmployeeName, newDepartment.Employees?[0].EmployeeName);
            }
            else
            {
                Assert.Fail("Deserialization returned null");
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
}

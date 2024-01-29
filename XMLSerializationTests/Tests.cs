using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Serialization;
using Common;
using System.Collections.Generic;

namespace XMLSerializationTests
{
    [TestClass]
    public class DepartmentAppTests
    {
        private string fileName = "test.xml";
        private Department? department;

        [TestMethod]
        public void TestXmlSerializationAndDeserialization()
        {
            // Init
            department = new Department()
            {
                DepartmentName = "Sales",
                Employees = new List<Employee> { new Employee { EmployeeName = "John Doe" } }
            };

            // Serialization into XML
            XmlSerializer formatter = new XmlSerializer(typeof(Department));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, department);
            }

            // Deserialozation from XML
            Department? newDepartment;
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                newDepartment = (Department)formatter.Deserialize(fs);
            }

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

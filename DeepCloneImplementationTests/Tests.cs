
using System.Text;
using Common;

namespace DeepCloneImplementationTests
{
    [TestClass]
    public class DepartmentTests
    {
        private Department department;

        [TestInitialize]
        public void TestInitialize()
        {
            department = new Department
            {
                DepartmentName = "Sales",
                Employees = new List<Employee> { new Employee { EmployeeName = "John Doe" } }
            };
        }

        [TestMethod]
        public void TestDeepClone()
        {
            var clone = DeepClone(department);

            clone.DepartmentName = "Marketing";
            clone.Employees.First().EmployeeName = "Jane Doe";

            Assert.AreEqual("Sales", department.DepartmentName);
            Assert.AreEqual("John Doe", department.Employees.First().EmployeeName);
            Assert.AreEqual("Marketing", clone.DepartmentName);
            Assert.AreEqual("Jane Doe", clone.Employees.First().EmployeeName);
        }

        private T DeepClone<T>(T original)
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
}

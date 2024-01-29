using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    [Serializable]
    public class Department : ISerializable
    {
        [XmlArray("Employees")]
        [XmlArrayItem("Employee")]
        [JsonProperty("Employees")]
        public List<Employee>? Employees  { get; set; }
        public string? DepartmentName { get; set; }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(DepartmentName);
            writer.Write(Employees?.Count ?? 0);
            if (Employees != null)
            {
                foreach (var employee in Employees)
                {
                    employee.Serialize(writer);
                }
            }
        }

        public void Deserialize(BinaryReader reader)
        {
            DepartmentName = reader.ReadString();
            int empCount = reader.ReadInt32();
            Employees = new List<Employee>();
            for (int i = 0; i < empCount; i++)
            {
                var emp = new Employee();
                emp.Deserialize(reader);
                Employees.Add(emp);
            }
        }
    }
}

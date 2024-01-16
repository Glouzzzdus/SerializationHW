using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common
{
    public class Department
    {
        [XmlArray("Employees")]
        [XmlArrayItem("Employee")]
        [JsonProperty("Employees")]
        public List<Employee> Employees { get; set; }
        public string DepartmentName { get; set; }
    }
}

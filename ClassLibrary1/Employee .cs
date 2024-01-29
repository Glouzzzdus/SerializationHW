namespace Common
{
    public class Employee : ISerializable
    {
        public string? EmployeeName { get; set; }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(EmployeeName);
        }

        public void Deserialize(BinaryReader reader)
        {
            EmployeeName = reader.ReadString();
        }
    }
}

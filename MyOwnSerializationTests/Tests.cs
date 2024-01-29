using Common;

namespace MyOwnSerializationTests
{
    [TestClass]
    public class SerializationTests
    {
        private string fileName = "test.dat";
        private SimpleClass simpleClass;

        [TestInitialize]
        public void TestInitialize()
        {
            simpleClass = new SimpleClass { Property1 = 5, Property2 = "Test" };
        }

        [TestMethod]
        public void TestBinarySerializationAndDeserialization()
        {
            // Serialization
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                simpleClass.Serialize(writer);
            }

            // Deserialization
            SimpleClass newSimpleClass = new SimpleClass();
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                newSimpleClass.Deserialize(reader);
            }

            // Check
            Assert.AreEqual(simpleClass.Property1, newSimpleClass.Property1);
            Assert.AreEqual(simpleClass.Property2, newSimpleClass.Property2);
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

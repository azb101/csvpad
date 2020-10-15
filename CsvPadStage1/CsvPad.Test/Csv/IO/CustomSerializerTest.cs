using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CsvPad.Csv
{
    [TestClass]
    public class CustomSerializerTest
    {
        private CustomSerializer serializer;
        
        string csv = @"c1;c2;c3
c1r1;'c2r1;""c3r1""
c'1'r2;c""2r2';c3r2""";

        StringReader reader;

        [TestInitialize]
        public void Init()
        {
            reader = new StringReader(csv);
            serializer = new CustomSerializer();
        }

        [TestCleanup]
        public void Cleanup()
        {
            reader.Close();
            reader.Dispose();
        }

        [TestMethod]
        public void Deserialize_WithHeader()
        {
            var table = serializer.Deserialize(reader, new CsvSettings());

            Assert.AreEqual("c1", table.Header[0].Value);
            Assert.AreEqual("c2", table.Header[1].Value);
            Assert.AreEqual("c3", table.Header[2].Value);

            Assert.AreEqual("c1r1", table[0][0].Value);
            Assert.AreEqual("'c2r1", table[0][1].Value);
            Assert.AreEqual("\"c3r1\"", table[0][2].Value);

            Assert.AreEqual("c'1'r2", table[1][0].Value);
            Assert.AreEqual("c\"2r2'", table[1][1].Value);
            Assert.AreEqual("c3r2\"", table[1][2].Value);
        }

        [TestMethod]
        public void Deserialize_WithoutHeader()
        {
            var table = serializer.Deserialize(reader, new CsvSettings { Header = false });

            Assert.AreEqual("c1", table[0][0].Value);
            Assert.AreEqual("c2", table[0][1].Value);
            Assert.AreEqual("c3", table[0][2].Value);

            Assert.AreEqual("c1r1", table[1][0].Value);
            Assert.AreEqual("'c2r1", table[1][1].Value);
            Assert.AreEqual("\"c3r1\"", table[1][2].Value);

            Assert.AreEqual("c'1'r2", table[2][0].Value);
            Assert.AreEqual("c\"2r2'", table[2][1].Value);
            Assert.AreEqual("c3r2\"", table[2][2].Value);
        }
    }
}

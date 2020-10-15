using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CsvPad.Csv.IO
{
    [TestClass]
    public class FileCsvServiceTest
    {
        private FileCsvService service;
        private Mock<CsvSerializer> serializerMock;

        [TestInitialize]
        public void Init()
        {
            serializerMock = new Mock<CsvSerializer>();
            service = new FileCsvService(serializerMock.Object, ".");
        }

        [TestMethod]
        public void DeleteTable_Success()
        {
            var filePath = GetTempFilePath();
            File.WriteAllText(filePath, "test");
            var location = new Uri($"file:///{filePath}");

            service.DeleteTable(location);

            Assert.IsFalse(File.Exists(filePath));
        }


        [TestMethod]
        public void GetTable_Success()
        {
            var filePath = GetTempFilePath();
            File.WriteAllText(filePath, "test");
            var location = new Uri($"file:///{filePath}");
            var settings = new CsvSettings { Header = false };

            var result = new CsvTable();
            serializerMock.Setup(c => c.Deserialize(It.IsAny<TextReader>(), settings))
                .Returns(result);
            
           
            var table = service.GetTable(location, settings);

            Assert.IsTrue(table == result);
        }

        [TestMethod]
        public void ValidateLocation_Valid()
        {
            Assert.IsTrue(service.ValidateLocation(new Uri("file:///C:/file.csv")));
        }

        [TestMethod]
        public void ValidateLocation_Invalid()
        {
            Assert.IsFalse(service.ValidateLocation(new Uri("http://localhost/file.csv")));
            Assert.IsFalse(service.ValidateLocation(new Uri("ftp://localhost/file.csv")));
            Assert.IsFalse(service.ValidateLocation(new Uri("test://file.csv")));
        }
        private string GetTempFilePath()
        {
            return new FileInfo(new Random(Environment.TickCount).Next().ToString()).FullName;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PdfHunter;

namespace PdfHunter.Unit.Test
{
    [TestClass]
    public class TestFileLink
    {
        [TestMethod]
        public void TestConstructor()
        {
            FileLink fileLink = new FileLink("fileName", "fileLink");
            Assert.IsTrue(fileLink.Name.Equals("fileName"));
            Assert.IsTrue(fileLink.Link.Equals("fileLink"));
        }

        [TestMethod]
        public void TestToString()
        {
            FileLink fileLink = new FileLink("fileName", "fileLink");
            Assert.IsTrue(fileLink.ToString().Equals("fileName: fileLink"));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PdfHunter;

namespace PdfHunter.Unit.Test
{
    [TestClass]
    public class TestUrlModification
    {
        [TestMethod]
        public void TestGithubBlobModification()
        {
            var modifications = new UrlModifications(new GithubBlob(), new GithubBlob());
            string oldURL = "https://github.com/.../blob/master/....pdf";
            string expectedNewURL = "https://github.com/.../raw/master/....pdf";
            string newURL = modifications.Apply(oldURL);
            Assert.IsTrue(newURL.Equals(expectedNewURL));
        }
    }
}

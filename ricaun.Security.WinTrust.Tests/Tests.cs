using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace ricaun.Security.WinTrust.Tests
{
    public class Tests
    {
        string Directory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [TestCase("ConsoleApp.exe", false)]
        [TestCase("ConsoleAppSigned.exe", true)]
        public void IsSignedFile_ShouldBe(string fileName, bool isSigned)
        {
            var filePath = Path.Combine(Directory, fileName);
            var result = Certificate.IsSignedFile(filePath);
            Assert.AreEqual(isSigned, result);
        }

        [TestCase("ConsoleApp.exe", false)]
        [TestCase("ConsoleAppSigned.exe", true)]
        public void VerifyEmbeddedSignature_ShouldBe(string fileName, bool isSigned)
        {
            var filePath = Path.Combine(Directory, fileName);
            var result = WinTrust.VerifyEmbeddedSignature(filePath);
            Assert.AreEqual(isSigned, result);
        }
    }
}
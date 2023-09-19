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
        [TestCase("ConsoleAppSignedNotTrusted.exe", true)]
        public void IsSignedFile_ShouldBe(string fileName, bool isSigned)
        {
            var filePath = Path.Combine(Directory, fileName);
            var result = Certificate.IsSignedFile(filePath);
            Assert.AreEqual(isSigned, result);
        }

        [TestCase("ConsoleApp.exe", false)]
        [TestCase("ConsoleAppSigned.exe", true)]
        [TestCase("ConsoleAppSignedNotTrusted.exe", false)]
        public void VerifyEmbeddedSignature_ShouldBe(string fileName, bool isSignedTrusted)
        {
            var filePath = Path.Combine(Directory, fileName);
            var result = WinTrust.VerifyEmbeddedSignature(filePath);
            Assert.AreEqual(isSignedTrusted, result);
        }

        [TestCase("C:\\Windows\\notepad.exe", false)]
        [TestCase("C:\\Windows\\explorer.exe", true)]
        public void Windows_VerifyEmbeddedSignature_ShouldBe(string filePath, bool isSigned)
        {
            if (File.Exists(filePath) == false)
                Assert.Ignore("File not found");

            var result = WinTrust.VerifyEmbeddedSignature(filePath);
            Assert.AreEqual(isSigned, result);
        }
    }
}
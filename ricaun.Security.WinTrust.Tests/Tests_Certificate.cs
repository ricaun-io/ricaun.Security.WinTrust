using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace ricaun.Security.WinTrust.Tests
{
    public class Tests_Certificate
    {
        string Directory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [TestCase("ConsoleAppSigned.exe", "Sectigo Public Code Signing CA R36")]
        [TestCase("ConsoleAppSignedNotTrusted.exe", "signfile")]
        public void GetSignedFileIssuerCode_ShouldBe(string fileName, string communName)
        {
            var filePath = Path.Combine(Directory, fileName);
            var result = Certificate.GetSignedFileIssuer(filePath, "cn");
            Assert.AreEqual(communName, result);
        }

        [TestCase("ConsoleAppSigned.exe", "ricaun")]
        [TestCase("ConsoleAppSignedNotTrusted.exe", "signfile")]
        public void GetSignedFileSubjectCode_ShouldBe(string fileName, string communName)
        {
            var filePath = Path.Combine(Directory, fileName);
            var result = Certificate.GetSignedFileSubject(filePath, "cn");
            Assert.AreEqual(communName, result);
        }

        [TestCase("ConsoleApp.exe", false)]
        [TestCase("ConsoleAppSigned.exe", true)]
        [TestCase("ConsoleAppSignedNotTrusted.exe", true)]
        public void GetSignedFileIssuer_ShouldBe(string fileName, bool isNotEmpty)
        {
            var filePath = Path.Combine(Directory, fileName);
            var result = Certificate.GetSignedFileIssuer(filePath);
            Assert.AreEqual(isNotEmpty, !string.IsNullOrEmpty(result));
        }

        [TestCase("ConsoleApp.exe", false)]
        [TestCase("ConsoleAppSigned.exe", true)]
        [TestCase("ConsoleAppSignedNotTrusted.exe", true)]
        public void GetSignedFileSubject_ShouldBe(string fileName, bool isNotEmpty)
        {
            var filePath = Path.Combine(Directory, fileName);
            var result = Certificate.GetSignedFileSubject(filePath);
            Assert.AreEqual(isNotEmpty, !string.IsNullOrEmpty(result));
        }

        [TestCase("C:\\Windows\\explorer.exe", "cn", "Microsoft Windows")]
        [TestCase("C:\\Windows\\explorer.exe", "o", "Microsoft Corporation")]
        public void Windows_GetSignedFileSubjectCode_ShouldBe(string filePath, string communName, string expected)
        {
            if (File.Exists(filePath) == false)
                Assert.Ignore("File not found");

            var result = Certificate.GetSignedFileSubject(filePath, communName);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Internal_SplitAndGetStartWith()
        {
            var baseString = "CN=signfile, OU=signfile1, O=signfile2, L=signfile3, S=signfile4, C=signfile5";
            var expectedValues = new Dictionary<string, string>() {
                {"cn","signfile"},
                {"ou","signfile1"},
                {"o","signfile2"},
                {"l","signfile3"},
                {"s","signfile4"},
                {"c","signfile5"},
            };

            foreach (var expectedValue in expectedValues)
            {
                var code = expectedValue.Key;
                var expected = expectedValue.Value;

                Assert.AreEqual(expected, Certificate.SplitAndGetStartWith(baseString, code));
                Assert.AreEqual(expected, Certificate.SplitAndGetStartWith(baseString, code + '='), "= should be Ignore");
                Assert.AreEqual(expected, Certificate.SplitAndGetStartWith(baseString, code.ToUpper()), "UpperCase be Ignore");
            }

            Assert.IsEmpty(Certificate.SplitAndGetStartWith(baseString, "a"));
            Assert.IsEmpty(Certificate.SplitAndGetStartWith(baseString, "b"));
        }
    }
}
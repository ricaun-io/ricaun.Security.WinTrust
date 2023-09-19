namespace ricaun.Security.WinTrust
{
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    /// <summary>
    /// Certificate
    /// </summary>
    public sealed class Certificate
    {
        /// <summary>
        /// Try to <see cref="X509Certificate.CreateFromSignedFile"/> to check if the file is signed.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsSignedFile(string fileName)
        {
            try
            {
                X509Certificate.CreateFromSignedFile(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get SignedFileIssuer
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <remarks>Return <see cref="string.Empty"/> if the <paramref name="fileName"/> is not signed.</remarks>
        public static string GetSignedFileIssuer(string fileName)
        {
            if (IsSignedFile(fileName))
            {
                return X509Certificate.CreateFromSignedFile(fileName).Issuer;
            }
            return string.Empty;
        }

        /// <summary>
        /// Get SignedFileSubject
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <remarks>Return <see cref="string.Empty"/> if the <paramref name="fileName"/> is not signed.</remarks>
        public static string GetSignedFileSubject(string fileName)
        {
            if (IsSignedFile(fileName))
            {
                return X509Certificate.CreateFromSignedFile(fileName).Subject;
            }
            return string.Empty;
        }

        /// <summary>
        /// Get SignedFileIssuer with the <paramref name="code"/> start with.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="code"></param>
        /// <remarks>Return <see cref="string.Empty"/> if the <paramref name="fileName"/> is not signed.</remarks>
        public static string GetSignedFileIssuer(string fileName, string code)
        {
            var subject = GetSignedFileIssuer(fileName);

            if (string.IsNullOrEmpty(subject)) return string.Empty;

            return SplitAndGetStartWith(subject, code);
        }

        /// <summary>
        /// Get SignedFileSubject with the <paramref name="code"/> start with.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="code"></param>
        /// <remarks>Return <see cref="string.Empty"/> if the <paramref name="fileName"/> is not signed.</remarks>
        public static string GetSignedFileSubject(string fileName, string code)
        {
            var subject = GetSignedFileSubject(fileName);

            if (string.IsNullOrEmpty(subject)) return string.Empty;

            return SplitAndGetStartWith(subject, code);
        }

        internal static string SplitAndGetStartWith(string subject, string codeStartWith)
        {
            const char ConstEqual = '=';
            const char ConstSeparator = ',';

            var texts = subject.Split(ConstSeparator)
                .Select(s => s.Trim());

            codeStartWith = codeStartWith.Trim().TrimEnd(ConstEqual) + ConstEqual;

            if (texts.FirstOrDefault(t => t.StartsWith(codeStartWith, System.StringComparison.InvariantCultureIgnoreCase)) is string text)
            {
                return text.Remove(0, codeStartWith.Length);
            }
            return string.Empty;
        }
    }
}
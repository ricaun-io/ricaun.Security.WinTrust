namespace ricaun.Security.WinTrust
{
    /// <summary>
    /// Certificate
    /// </summary>
    public sealed class Certificate
    {
        /// <summary>
        /// Try to <see cref="System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromSignedFile"/> to check if the file is signed.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsSignedFile(string fileName)
        {
            try
            {
                System.Security.Cryptography.X509Certificates.X509Certificate.CreateFromSignedFile(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

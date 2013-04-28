namespace CohesionAndCoupling
{
    using System;
    using System.Linq;

    public static class FileExtensionUtils
    {
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }
    }
}

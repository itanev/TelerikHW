using Ionic.Zip;
using System.Reflection;
using System.Xml;
using System.Configuration;

//add this to App.config file in the project that will use this class library
//<appSettings>
//    <add key="ZipPath" value="..\..\..\Sample-Sales-Reports.zip"/>
//    <add key="OutputFolder" value="..\..\..\uzip"/>
//  </appSettings>

namespace LoadExcelReports
{
    public static class ZipExtractor
    {
        public static void Extract()
        {
            string zipToUnpack = ConfigurationManager.AppSettings["ZipPath"];
            string unpackDirectory = ConfigurationManager.AppSettings["OutputFolder"];
            using (ZipFile zip = ZipFile.Read(zipToUnpack))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}

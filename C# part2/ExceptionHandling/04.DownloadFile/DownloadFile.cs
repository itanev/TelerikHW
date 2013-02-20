using System;
using System.Net;

class DownloadFile
{
    static void Main()
    {
        try
        {
            string remoteUri = "http://www.devbg.org/img/Logo-BASD.jpg";

            WebClient myWebClient = new WebClient();
            myWebClient.DownloadFile(remoteUri, "logo.jpg");
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine("The remote URI or the file name you provided are invalid." + ae.Message);
        }
        catch (FieldAccessException fae)
        {
            Console.WriteLine("You don't have permission to access this file." + fae.Message);
        }
        catch (WebException we)
        {
            Console.WriteLine("Either the URI format is not valid or filename is empty string or the file does not exist." + we.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine("The method has been called simultaneously on multiple threads." + nse.Message);
        }
        finally
        {
            Console.WriteLine("The file is downloaded");
        }
    }
}
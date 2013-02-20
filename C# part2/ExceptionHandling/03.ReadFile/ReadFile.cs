using System;
using System.IO;

class ReadFile
{
    static void Main()
    {
        try
        {
            Console.Write("Please enter file name: ");
            string fileName = Console.ReadLine();
            Console.Write("Please enter file path: ");
            string filePath = Console.ReadLine();

            StreamReader readFile = new StreamReader(filePath + fileName);
            Console.WriteLine( readFile.ReadToEnd() );
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("You must enter something for file name and/or file path.");
        }
        catch (PathTooLongException ptle)
        {
            Console.WriteLine("Too long file name and/or file path." + ptle.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine("The file path appears ot be invalid. It may be on unmapped drive." + dnfe.Message);
        }
        catch (UnauthorizedAccessException uae)
        {
            Console.WriteLine("You don't have permissions to access this file" + uae.Message);
        }
        catch(FileNotFoundException fnfe)
        {
            Console.WriteLine("File does not exist." + fnfe.Message);
        }
        catch (NotSupportedException nse)
        {
            Console.WriteLine("Path is in an invalid format." + nse.Message);
        }
    }
}
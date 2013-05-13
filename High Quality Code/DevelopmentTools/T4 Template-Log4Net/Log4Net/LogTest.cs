using log4net;
using log4net.Config;

public class LogTest
{
    /// <summary>
    /// You can see the configuration file Log4Net.exe.config in the bin directory
    /// LogTest2.txt is the file where the loged information is saved.
    /// The logger also prints the information on the console.
    /// This is all configured in the configuration file.
    /// </summary>
    private static readonly ILog logger = LogManager.GetLogger(typeof(LogTest));

    static LogTest()
    {
        DOMConfigurator.Configure();
    }

    static void Main()
    {   
        logger.Debug("Here is a debug log.");
        logger.Info("... and an Info log.");
        logger.Warn("... and a warning.");
        logger.Error("... and an error.");
        logger.Fatal("... and a fatal error.");
    }
}
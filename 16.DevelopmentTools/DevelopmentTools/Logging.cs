namespace DevelopmentTools
{
    using System;
    using System.Reflection;
    using log4net;
    using log4net.Config;

    // Helpful articles
    // http://logging.apache.org/log4net/release/manual/configuration.html
    // http://logging.apache.org/log4net/release/config-examples.html

    public class Logging
    {
        // Using reflection to get the current object
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main()
        {
            // Configuration is in App.config file
            // Log messages are diplayed on the console and in file Logging.log in Debug folder
            XmlConfigurator.Configure();

            Log.Info("Info log message!");
            Log.Warn("Warning log message!");
            Log.Error("Error log message!");

            try
            {
                // This simple exception is just for the demonstration!
                int zero = 0;
                int result = 5 / zero;
            }
            catch (DivideByZeroException exc)
            {
                Log.Fatal(exc);
            }
        }
    }
}

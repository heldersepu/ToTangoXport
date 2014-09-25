using System;
using NLog;

namespace absToTango
{
    public class nlog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void SaveException(Exception e)
        {
            logger.Error(e);
        }

        public static string SaveDebug(string message)
        {
            logger.Debug(message);
            return message;
        }
    }
}

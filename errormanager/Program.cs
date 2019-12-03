using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace errormanager
{
    public class ErrorLogger
    {
        static void Main(string[] args)
        {
            ILogger logger = null;
            int n;
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 1)
            {
                logger = new TextLogger();
            }
            else if (n == 2)
            {
                logger = new DatabaseLogger();
            }

            LogManager logManager = new LogManager();
            logManager.Log(logger, "Server Error");

        }
    }
    public class LogManager
    {
        //ILogger tLog = new TextLogger();
        ILogger tLog;

        //public LogManager(ILogger logger)
        //{
        //    tLog = logger;
        //}

        public void Log(ILogger logger,string error)
        {
            tLog = logger;
            tLog.Log(error);
        }
    }
    public class TextLogger : ILogger
    {
        public void Log(string error)
        {
            Console.WriteLine($"Error logged in Text file {error} on {DateTime.Now}");
        }


    }
    public class DatabaseLogger : ILogger
    {
        public void Log(string error)
        {
            Console.WriteLine($"Database logged in database file{error} on{DateTime.Now}");
        }
    }
    public interface ILogger
    {
        void Log(string error);
    }
}

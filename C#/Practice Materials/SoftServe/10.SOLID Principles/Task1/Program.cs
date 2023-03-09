using System;
using System.IO;

namespace Task1
{
    class Program
    {
        public interface ILogger
        {
            void LogMessage(string message);
        }
        //empldataaaces
        public class DbLogger : ILogger
        {
            public void LogMessage(string mMessage)
            {
                //Code to write message in database.  
            }
        }

        public class FileLogger : ILogger
        {
            public void LogMessage(string mStackTrace)
            {
                //code to log stack trace into a file.  
            }
        }
        //bussinessLogic
        public class ExceptionLogger : ILogger
        {
            private ILogger _logger;
            public ExceptionLogger(ILogger logger)
            {
                _logger = logger;
            }
            public void LogException(Exception exception)
            {
                ILogger objFileLogger = new ExceptionLogger(_logger);
                objFileLogger.LogMessage(GetUserReadableMessage(exception));
            }
            public void LogIntoFile(Exception mException)
            {
                ILogger objFileLogger = new FileLogger();
                objFileLogger.LogMessage(GetUserReadableMessage(mException));
            }
            public void LogIntoDataBase(Exception mException)
            {
                ILogger objDbLogger = new DbLogger();
                objDbLogger.LogMessage(GetUserReadableMessage(mException));
            }
            private string GetUserReadableMessage(Exception ex)
            {
                string strMessage = string.Empty;
                //code to convert Exception's stack trace and message to user   
                // readable format.  
                return strMessage;
            }

            public void LogMessage(string message)
            {
                throw new NotImplementedException();
            }
        }

        //DataAccessFactory
        public class DataExporter
        {
            private ILogger _logger;
            public void ExportDataFromFile()
            {
                try
                {
                    //code to export data from files to database.  
                }
                catch (IOException ex)
                {
                    new ExceptionLogger(_logger).LogIntoDataBase(ex);
                }
                catch (Exception ex)
                {
                    new ExceptionLogger(_logger).LogIntoFile(ex);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

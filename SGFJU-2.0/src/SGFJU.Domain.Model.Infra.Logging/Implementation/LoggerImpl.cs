
using SGFJU.Domain.Model.Infra.Logging.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Logging.Implementation
{
    public class LoggerImpl : SGFJU.Domain.Model.Infra.Logging.Abstractions.Logger
    {

        public LoggerImpl()
        {
            //ConfigureDefaultLogger(this.GetType().Name);
        }

        public LoggerImpl(string loggerName, string sourceFolderFileLog)
        {
            if (FolderLogExist(sourceFolderFileLog))
                ConfigureLogger(loggerName, sourceFolderFileLog);
            else
                throw new ArgumentException("Source folder doesen´t exist !");
        }

        private bool FolderLogExist(string sourceFolderFileLog)
        {
            return (Directory.Exists(sourceFolderFileLog));
        }

        private void ConfigureLogger(string loggerName, string sourceFolderFileLog)
        {
            //var fileAppender = new FileAppender
            //{
            //    File = sourceFolderFileLog + loggerName + ".txt",
            //    Name = "LoggerImplAppender"
            //};

            //var loggerRepository = log4net.LogManager.GetRepository(GetType().Assembly);

            //log4net.Config.BasicConfigurator.Configure(loggerRepository);

            //__currentLogger = LogManager.GetLogger(GetType().Assembly, loggerName);
        }

        public string LoggerName { get; private set; }



        public virtual void WriteLog(string message)
        {
            
        }

        public void WriteLogException(string errorMessage, Exception exception)
        {
            
        }

    }
}

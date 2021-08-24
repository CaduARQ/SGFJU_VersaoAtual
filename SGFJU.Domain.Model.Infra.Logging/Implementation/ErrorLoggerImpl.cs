
using NLog;
using NLog.Fluent;
using SGFJU.Domain.Model.Infra.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Logging.Implementation
{
    public class ErrorLoggerImpl : LoggerImpl, ErrorLogger
    {
        private string __pathErrorLogger;
        public ErrorLoggerImpl()
            : base()
        {
            
        }

        public ErrorLoggerImpl(string pathErroLogFile)
        {
            this.__pathErrorLogger = pathErroLogFile;
        }

        public override void WriteLog(string message)
        {
            var logger = LogManager.GetCurrentClassLogger();


            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = this.__pathErrorLogger };
            //var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Error, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;


            logger.Error()
                .Message("Erro ocorrido '{0}' - Descrição do Erro: {1}", DateTime.Now, message)
                .Property("ErrorLogger", "InfoWrite")
                .Write();
        }

        public void WriteExceptionLog(string errorMessage, Exception exception)
        {
            //__currentLogger.Error(exception);
        }
    }
}

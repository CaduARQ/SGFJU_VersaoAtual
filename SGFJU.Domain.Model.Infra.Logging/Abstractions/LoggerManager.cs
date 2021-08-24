using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Logging.Abstractions
{
    public abstract class LoggerManager
    {
        public abstract Logger GetErrorLog(string loggerName);
        public abstract Logger GetUserLog(string loggerName);
        public abstract Logger GerLog(string loggerName);
    }
}

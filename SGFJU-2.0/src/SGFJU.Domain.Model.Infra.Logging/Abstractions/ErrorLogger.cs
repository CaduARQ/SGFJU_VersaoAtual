using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Logging.Abstractions
{
    public interface ErrorLogger : Logger
    {
       void WriteLogException(string errorMessage, Exception exception);
    }
}

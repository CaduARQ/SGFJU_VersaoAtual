using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Logging.Abstractions
{
    public interface Logger
    {
        void WriteLog(string message);
    }
}

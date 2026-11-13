using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Logging.Abstractions
{
    public interface UserLogger : Logger
    {
        void WriteUserAction(string message, string action, Usuario user);
    }
}

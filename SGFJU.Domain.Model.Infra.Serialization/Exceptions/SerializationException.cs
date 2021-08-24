using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Serialization.Exceptions
{
    public class SerializationException : Exception
    {
        public SerializationException(string message) : base(message) { }
        public SerializationException(string message, Exception exception) : base(message, exception) { }
    }
}

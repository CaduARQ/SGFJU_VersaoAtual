using SGFJU.Domain.Model.DomainExceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade.Exceptions
{
    public class FacadeException : Exception
    {
        public FacadeException(string exceptionMessage, DomainException domainException) : base(exceptionMessage, domainException)
        {

        }

        public FacadeException(string exceptionMessage, Exception domainException) : base(exceptionMessage, domainException)
        {

        }
    }
}

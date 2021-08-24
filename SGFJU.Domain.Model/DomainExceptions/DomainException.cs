using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SGFJU.Domain.Model.DomainExceptions
{
    [Serializable]
    public class DomainException : Exception
    {

        public DomainException() { }
        public DomainException(string MessageValidationException) : base(MessageValidationException) {
            this.MensagemExcecaoDetalhada = MessageValidationException;
        }
        public DomainException(string ruleBrokenMessageException, Exception exception) : base(ruleBrokenMessageException, exception)
        {
            _ruleBrokenDescription = ruleBrokenMessageException;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("RuleBrokenDescription", _ruleBrokenDescription);

            base.GetObjectData(info, context);
        }

        private string _ruleBrokenDescription;
        protected string RuleBrokenDescription
        {
            get
            {
                return _ruleBrokenDescription;
            }
            set
            {
                _ruleBrokenDescription = value;
            }
        }

        public string MensagemExcecaoDetalhada { get; set; }

        public string CamadaExcecao { get; set; }

        public string Metodo { get; set; }
    }
}

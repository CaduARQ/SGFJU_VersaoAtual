using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class RedeSocial : ValueObject<RedeSocial>{

        public virtual string Facebook { get; set; }
        public virtual string Instagram { get; set; }
        public virtual string Email { get; set; }
        public virtual string Twitter { get; set; }
        public virtual char EhSeguidorOficialFJU { get; set; }

        public virtual char EhSeguidorYoutube { get; set; }

        public virtual char EhSeguidorTelegram { get; set; }

        public virtual char EhAssinanteUNIVER { get; set; }

        public virtual string FrequenciaAssisteUNIVER { get; set; }

        public virtual char EhLeitorBlogBM { get; set; }

        public virtual char EhLeitorUniversalorg { get; set; }

        public virtual char PossuiCelularComInternet { get; set; }

        public virtual char PossuiComputador { get; set; }
        
    }
}

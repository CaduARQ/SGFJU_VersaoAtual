using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class RedeSocialDTO
    {
        public int Code { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public char EhSeguidorOficialFJU { get; set; }

        public char EhSeguidorYoutube { get; set; }

        public char EhSeguidorTelegram { get; set; }

        public char EhAssinanteUNIVER { get; set; }

        public string FrequenciaAssisteUNIVER { get; set; }

        public char EhLeitorBlogBM { get; set; }

        public char EhLeitorUniversalorg { get; set; }

        public char PossuiCelularComInternet { get; set; }

        public char PossuiComputador { get; set; }
    }
}

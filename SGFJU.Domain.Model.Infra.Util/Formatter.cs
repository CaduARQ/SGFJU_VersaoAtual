using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SGFJU.Domain.Model.Infra.Util
{
    public class Formatter {
        public static string formataMesAno(string mesAnoParametro)
        {
            if (string.IsNullOrEmpty(mesAnoParametro) || mesAnoParametro == null)
                return "";
            var mesAnoRetorno = string.Empty;
            var dataParametro = new DateTime();
            if (ehMesEAnoValido(mesAnoParametro))
            {
                mesAnoRetorno = mesAnoParametro;
                mesAnoRetorno = (mesAnoRetorno.IndexOf('/') != -1) ?
                                   mesAnoParametro :
                                   (mesAnoRetorno.Length == 6) ?
                                      mesAnoRetorno.Substring(0, 2) + "/" + mesAnoRetorno.Substring(2, 4) :
                                      mesAnoRetorno;
            }
            else if (ehDataInvertida(mesAnoParametro))
            {
                var ano = Regex.Match(mesAnoParametro, @"[0-9]{4}/").Value.Replace("/", "");
                var mes = Regex.Match(mesAnoParametro, @"/[0-9]{1,2}").Value.Replace("/", "");
                mesAnoRetorno = mes + "/" + ano;
            }
            else if (DateTime.TryParse(mesAnoParametro, out dataParametro))
            {
                var ano = DateTime.Parse(mesAnoParametro).Year;
                var mes = DateTime.Parse(mesAnoParametro).Month;
                mesAnoRetorno = mes + "/" + ano;
            }
            return mesAnoRetorno;
        }
        internal static bool ehMesEAnoValido(string pMesAnoChegadaIURD)
        {
            var mesEAnoValido = false;

            if (string.IsNullOrEmpty(pMesAnoChegadaIURD))
            {
                mesEAnoValido = false;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') != -1 &&
                     pMesAnoChegadaIURD.Length < 6)
            {
                mesEAnoValido = false;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') == -1 &&
                     pMesAnoChegadaIURD.Length == 6)
            {
                mesEAnoValido = true;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') != -1 &&
                     (pMesAnoChegadaIURD.Length == 7 || pMesAnoChegadaIURD.Length == 6) &&
                     (!ehDataInvertida(pMesAnoChegadaIURD)))
            {
                mesEAnoValido = true;
            }
            else if (pMesAnoChegadaIURD.IndexOf('/') == -1 &&
                     pMesAnoChegadaIURD.Length == 4 &&
                     (int.Parse(pMesAnoChegadaIURD) >= 1977 && int.Parse(pMesAnoChegadaIURD) <= DateTime.Now.Year))
            {
                mesEAnoValido = true;
            }

            return mesEAnoValido;
        }

        protected static bool ehDataInvertida(string pMesAno)
        {
            var dataEstaInvertida = (Regex.Match(pMesAno, @"[0-9]{4}/").Value.Replace("/", "").Length == 4) ? true : false;
            if (dataEstaInvertida)
            {
                return true;
            }
            return false;
        }
    }
}

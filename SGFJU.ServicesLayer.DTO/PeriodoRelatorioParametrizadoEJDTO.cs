using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SGFJU.ServicesLayer.DTO.Relatorios
{
    public class PeriodoRelatorioParametrizadoEJDTO
    {
        public string DataInicialParametro { get; set; }
        public string DataFinalParametro { get; set; }
        public bool ParametroVigente { get; set; }

        public PeriodoRelatorioEJDTO ConverteParaPeriodoRelatorioEJDTO() {
            if (!string.IsNullOrEmpty(this.DataInicialParametro) &&
               !string.IsNullOrEmpty(this.DataFinalParametro))
                return new PeriodoRelatorioEJDTO { 
                        DataInicial = DateTime.Parse(this.DataInicialParametro).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR")), 
                        DataFinal = DateTime.Parse(this.DataFinalParametro).ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR")), 
                        EhPeriodoParametrizado = true 
                };

            throw new Exception("Não é possível realizar a conversão pois uma das datas estão em branco");
        }
    }
}

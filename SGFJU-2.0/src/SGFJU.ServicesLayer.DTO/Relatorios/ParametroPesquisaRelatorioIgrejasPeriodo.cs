using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO.Relatorios
{
    public class ParametroPesquisaRelatorioIgrejasPeriodo
    {
        public int IdEstado { get; set; }
        public int IdBloco { get; set; }
        public int IdRegiao { get; set; }
        public int IdIgreja { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public int IdReuniao { get; set; }
    }
}

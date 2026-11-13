using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.ServicesLayer.DTO
{
    public class DadosEspirituaisDTO
    {
        public int Code { get; set; }
        public char EhMembroIURD { get; set; }
        public string MesAnoChegadaIURD { get; set; }
        public int AnoChegadaiurd { get; set; }
        public int MesChegadaiurd { get; set; }
        public char EhBatizadoEspiritoSanto { get; set; }
        public string MesAnoBatismoEspiritoSanto { get; set; }
        public string OcasiaoBatismoEspiritoSanto { get; set; }
        public string ComoConheceuIURD { get; set; }
        public char JaSeAfastou { get; set; }
        public string MotivoSeAfastou { get; set; }
        public string MesAnoAfastamento { get; set; }
        public string TempoAfastamento { get; set; }
        public string TempoEstaFirme { get; set; }
        public char TemFamiliaresIURD { get; set; }
        public string DescricaoFamiliaresIURD { get; set; }
        public char EhBatizadoAguas { get; set; }
        public string MesAnoBatismoAguas { get; set; }
        public char BatismoAguasIURD { get; set; }
        public string DescricaoModoChegouFJU { get; set; }
        public string MesAnoEntradaFJU { get; set; }
        public string MotivoEntradaFJU { get; set; }
        public char PossuiBiblia { get; set; }
        public char PossuiBibliaNoCelular { get; set; }
        public char LeuTodaBiblia { get; set; }
        public int idFrequenciaLeituraBiblia { get; set; }
    }
}

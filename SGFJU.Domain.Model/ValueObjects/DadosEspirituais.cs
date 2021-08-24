using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.ValueObjects
{
    public class DadosEspirituais : ValueObject<DadosEspirituais>
    {
        public virtual char EhMembroIURD { get; set; }
        public virtual string MesAnoChegadaIURD { get; set; }
        public virtual int AnoChegadaiurd { get; set; }
        public virtual int MesChegadaiurd { get; set; }
        public virtual char EhBatizadoEspiritoSanto { get; set; }
        public virtual string MesAnoBatismoEspiritoSanto { get; set; }
        public virtual string OcasiaoBatismoEspiritoSanto { get; set; }
        public virtual string ComoConheceuIURD { get; set; }
        public virtual char JaSeAfastou { get; set; }
        public virtual string  MotivoSeAfastou { get; set; }
        public virtual string MesAnoAfastamento { get; set; }
        public virtual string TempoAfastamento { get; set; }
        public virtual string TempoEstaFirme { get; set; }
        public virtual char TemFamiliaresIURD { get; set; }
        public virtual string DescricaoFamiliaresIURD { get; set; }
        public virtual char EhBatizadoAguas { get; set; }
        public virtual string MesAnoBatismoAguas { get; set; }
        public virtual char BatismoAguasIURD { get; set; }
        public virtual string DescricaoModoChegouFJU { get; set; }
        public virtual string MesAnoEntradaFJU { get; set; }
        public virtual string MotivoEntradaFJU { get; set; }
        public virtual char PossuiBiblia { get; set; }
        public virtual char PossuiBibliaNoCelular { get; set; }
        public virtual char LeuTodaBiblia { get; set; }
        public virtual FrequenciaLeitura FrequenciaLeituraBiblia { get; set; }
    }
}

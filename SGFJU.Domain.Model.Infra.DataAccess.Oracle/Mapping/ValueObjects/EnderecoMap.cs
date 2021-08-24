using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql.Mapping.ValueObjects
{
    public class EnderecoMap : ClassMap<Endereco>{
        public EnderecoMap()
        {
            this.Table("SGFJU_TBL_ENDERECO");
            this.Id(t => t.Code, "ID_ENDERECO").GeneratedBy.Identity();
            this.Map(t => t.DescricaoEndereco);
            this.Map(t => t.Cidade);
            this.Map(t => t.NomeEstado);
            this.Map(t => t.Bairro);
            this.References<TipoMoradia>(t => t.TipoDeMoradia)
                .Column("ID_TIPOMORADIA")
                .Cascade
                .None()
                .Not
                .LazyLoad();
        }
    }
}

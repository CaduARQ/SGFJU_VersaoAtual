using System;
using System.Collections.Generic;
using System.Text;
using SGFJU.Domain.Model.Entities;
using FluentNHibernate.Mapping;
using SGFJU.Domain.Model.ValueObjects;

namespace SGFJU.Domain.Model.Infra.DataAccess.MySql
{
    public class JovemMap : ClassMap<Jovem>
    {
        public JovemMap() {
            this.Table("SGFJU_TBL_JOVEM");
            this.Id(t => t.Id, "ID_JOVEM").GeneratedBy.Identity();
            this.Map(t => t.Nome);
            this.Map(t => t.NomeArquivoFoto);
            this.Map(t => t.NomeConjuge);
            this.Map(t => t.DataCasamento);
            this.Map(t => t.PossuiFilhos);
            this.Map(t => t.QuantidadeFilhos);
            this.Map(t => t.ConjugeEhIURD);
            this.Map(t => t.ConjugeEhObreiro);
            this.Map(t => t.NamoraAtualmente);
            this.Map(t => t.GostaDeAlguem);
            this.Map(t => t.NomePretendente);
            this.Map(t => t.PossuiTituloEleitor);
            this.Map(t => t.PertenceGrupoMulheresIURD);
            this.Map(t => t.NomeGrupoMulheresIURD);
            this.Map(t => t.DataNascimento);
            this.Map(t => t.DataCadastro);
            this.Map(t => t.DataPreenchimentoFormulario);
            this.Map(t => t.DataUltimaAtualizacao);
            this.Map(t => t.DataIngressoObra);
            this.Map(t => t.TextoSugestao);
            this.Map(t => t.Sexo);
            this.Map(t => t.ClassificacaoJovem);
            this.Map(t => t.DataMudancaClassificacaoJovem);
            this.Map(t => t.DescricaoMudancaClassificacaoJovem);
            this.Map(t => t.AutorizadorMudancaClassificacaoJovem);
            this.Map(x => x.EhPastor);
            this.Map(x => x.EhAltarJovem318);
            this.Map(x => x.CodigoAltarJovem318);
            this.Map(x => x.EhAtendenteWhatsappHelp);


            this.References<Contato>(t => t.ContatoJovem)
                .Column("ID_CONTATO")
                .Cascade
                .None().Not.LazyLoad();
            this.References<RedeSocial>(t => t.RedeSocialJovem)
                .Column("ID_REDESOCIAL")
                .Cascade
                .None().Not.LazyLoad();
            this.References<Endereco>(t => t.EnderecoJovem)
                .Column("ID_ENDERECO")
                .Cascade
                .None().Not.LazyLoad();
            this.References<DadosProfissionais>(t => t.DadosProfissionaisJovem)
                .Column("ID_DADOS_PROFISSIONAIS")
                .Cascade
                .None().Not.LazyLoad();
            this.References<TipoEstadoCivil>(t => t.EstadoCivilJovem)
                .Column("ID_TIPOESTADOCIVIL")
                .Cascade
                .None().Not.LazyLoad();
            this.References<DadosEducacionais>(t => t.DadosEducacionaisJovem)
                .Column("ID_DADOSESCOLARES")
                .Cascade
                .None().Not.LazyLoad();
            this.References<DadosEspirituais>(t => t.DadosEspirituaisJovem)
                .Column("ID_DADOSESPIRITUAIS")
                .Cascade
                .None().Not.LazyLoad();
            this.References<SituacaoIURDFJU>(t => t.SituacaoJovemIURDFJU)
                .Column("ID_SITUACAO_IURD_FJU")
                .Cascade
                .None().Not.LazyLoad();
            this.References<Igreja>(t => t.IgrejaAQualJovemPertence)
                .Column("ID_IGREJA")
                .Cascade
                .None().Not.LazyLoad();

            //HasMany
            this.HasMany(x => x.CursosRelacionados)
                .Access
                .CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan()
                .AsBag().Not.LazyLoad();

            HasManyToMany(x => x.DepartamentosProjetoJovemFazParte)
                .Cascade.None()
                .Table("SGFJU_TBL_JOVEM_DEPTO_PROJETO")
                .Not.LazyLoad();

            HasManyToMany(x => x.LivrosLidosPeloJovem)
                .Cascade.None()
                .Table("SGFJU_TBL_JOVEM_LIVROLIDO")
                .Not.LazyLoad();

            HasManyToMany(x => x.ReunioesFJUAssistidasPeloJovem)
                .Cascade.None()
                .Table("SGFJU_TBL_JOVEM_REUNIAOFJU")
                .Not.LazyLoad();

            //Mapeamento ManyToMany onde há colunas na tabela de associação            
            /*
            No NHibernate inclusive com FluentMapping, quando na tabela de associação ManyToMany há colunas
            temos que mapear os dois lados como One-To-Many e a tabela de associação, mapeamos
            como uma entidade.
            Devido a isto os mapeamentos abaixo estão separados
            */
            HasMany(x => x.IdiomasQueOJovemFala)
                .AsBag()
                .Cascade.All() 
                .Table("SGFJU_TBL_JOVEM_IDIOMA");

            HasMany(x => x.ProjetosAosQuaisJovemEstaLigado)
                .AsBag()
                .Cascade.All()
                .Table("SGFJU_TBL_JOVEM_PROJETO");

            HasMany(x => x.HabilidadesJovemPossui)
                .AsBag()
                .Cascade.All()
                .Table("SGFJU_TBL_JOVEM_HABILIDADE");

            HasMany(x => x.IgrejaQueCoordena)
                .AsBag()
                .Cascade.All()
                .Table("SGFJU_TBL_IGREJA_COORDENADOR");

            HasMany(x => x.ObreiroQueAcompanha)
                .AsBag()
                .Cascade.All()
                .Table("SGFJU_TBL_ARVOREVIDA_JOVEMOBREIRO");

            HasMany(x => x.HistoricoAcompanhamentoJovem)
                .AsBag()
                .Cascade.All()
                .Table("SGFJU_TBL_ARVOREVIDA_HISTORICOACOMPANHAMENTO");
        }
    }
}

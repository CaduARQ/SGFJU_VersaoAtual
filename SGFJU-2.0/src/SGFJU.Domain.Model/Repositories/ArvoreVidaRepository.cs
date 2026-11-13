using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface ArvoreVidaRepository : Repository<Jovem> {
        void AssociaJovensAObreiro(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanha);
        void DesassociaJovensDeObreiro(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanhava);
        void RegistraHistoricoJovem(JovemHistorico historicoDoJovem);
        IList<TodosJovensDTO> ListaJovensAcompanhadosPorObreiro(ObreiroDTO obreiro);
        ObreiroDTO RetornaObreiroQueAcompanhaJovem(Jovem jovemParametro);
        IList<ObreiroDTO> PesquisaObreiroPorParametro(ParametroPesquisaObreiroDTO parametroPesquisaObreiro);
        IList<TodosJovensDTO> ListaJovensIgrejaObreiroSemAcompanhamento(ObreiroDTO obreiroParametro);
        AcompanhamentoJovemDTO RetornaHistoricoAcompanhamentoJovem(JovemDTO jovemParametro);
        IList<TodosJovensDTO> ListaJovensEmAcompanhamentoPorParametro(PesquisaGeralDTO parametroPesquisa);
        DataValidaHistoricoDTO EhDataHistoricoAcompanhamentoValida(string pDataHistorico, int pIdJovem);
        ObreiroDTO ObterObreiroPorIDX(IdXDTO idxObreiroParametro);
        IList<ObreiroDTO> ListaObreirosComRamosPorParametro(PesquisaGeralDTO parametrosPesquisa);
        IList<ObreiroDTO> ListarObreirosSemRamosAVPorParametro(PesquisaGeralDTO parametrosPesquisa);
    }
}
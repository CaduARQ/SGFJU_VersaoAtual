using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface FacadeArvoreVida
    {
        void AssociaJovensAObreiro(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanha);
        void DesassociaJovensDeObreiro(IList<JovemAcompanhamentoDTO> JovensAcompanhados, ObreiroDTO ObreiroQueAcompanhava);
        void RegistraHistoricoJovem(JovemHistorico historicoDoJovem);
        IList<TodosJovensDTO> ListaJovensAcompanhadosPorObreiro(ObreiroDTO obreiro);
        ObreiroDTO RetornaObreiroQueAcompanhaJovem(Jovem jovemParametro);
        AcompanhamentoJovemDTO RetornaHistoricoAcompanhamentoJovem(JovemDTO jovemParametro);
        IList<TodosJovensDTO> ListaJovensEmAcompanhamentoPorParametro(PesquisaGeralDTO parametroPesquisa);
        DataValidaHistoricoDTO EhDataHistoricoAcompanhamentoValida(string pDataHistorico, int pIdJovem);
        IList<ObreiroDTO> ListaObreirosComRamosPorParametro(PesquisaGeralDTO parametrosPesquisa);
        IList<ObreiroDTO> ListarObreirosSemRamosAVPorParametro(PesquisaGeralDTO parametrosPesquisa);
    }
}

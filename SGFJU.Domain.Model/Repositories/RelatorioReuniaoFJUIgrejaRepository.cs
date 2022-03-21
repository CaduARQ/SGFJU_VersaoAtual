using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface RelatorioReuniaoFJUIgrejaRepository : Repository<RelatorioReuniaoFJUIgreja>
    {
        RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgreja(RelatorioReuniaoFJUIgrejaDTO relatorio);
        RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgrejas(IList<RelatorioReuniaoFJUIgrejaDTO> relatorios);
        RespostaProcessamentoFechamentoRelatorioDTO ProcessarFechamentoRelatorioDTO(FechamentoRelatorioDTO parametroFechamentoRelatorio);
        IList<RelatorioReuniaoFJUIgrejaDTO> ListaRelatorioIgrejasEstadoPorPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo parametrosPesquisa);
        bool RelatorioDaIgrejaJaLancadoNoPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo periodoEmQuestao);
    }
}

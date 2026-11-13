using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface FacadeRelatorioReuniaoFJUIgreja : Facade<RelatorioReuniaoFJUIgreja> {
        RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgreja(RelatorioReuniaoFJUIgrejaDTO relatorio);
        RespostaProcessamentoRelatorioDTO ProcessarRelatorioIgrejas(IList<RelatorioReuniaoFJUIgrejaDTO> relatorios);
        RespostaProcessamentoFechamentoRelatorioEstadoDTO ProcessarFechamentoRelatorioEstado(FechamentoRelatorioEstadoDTO parametroFechamentoRelatorio);
        RespostaProcessamentoFechamentoRelatorioBlocoDTO ProcessarFechamentoRelatorioBloco(ProcessaFechamentoRelatorioBlocoDTO parametroFechamentoRelatorioBloco);
        IList<RelatorioReuniaoFJUIgrejaDTO> ListaRelatorioIgrejasEstadoPorPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo parametrosPesquisa);
        bool RelatorioDaIgrejaJaLancadoNoPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo periodoEmQuestao);
        RespostaProcessamentoRelatorioDTO AtualizaRelatorioPeriodo(RelatorioReuniaoFJUIgrejaDTO relatorioASerAtualizado);
        bool RelatorioNoPeriodoJaEstaProcessado(ParametroPesquisaRelatorioIgrejasPeriodo parametrosVerificacao);
        RelatorioConsolidadoEstadualSemanal RetornaRelatorioConsolidadoEstadoPorPeriodo(ParametroPesquisaRelatorioIgrejasPeriodo parametros);
    }
}

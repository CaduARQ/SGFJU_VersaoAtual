using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface DashboardRelatorioBlocoFacade : Facade<DashboardRelatorioBloco> {
        IList<RelatorioBlocoTotaisGeraisDTO> RetornaTotaisBlocosNacional();
        RelatorioBlocoTotaisGeraisDTO RetornaRelatorioTotaisPorbloco(Bloco blocoParametro);
        IList<RelatorioBlocoTotaisGeraisDTO> RetornaTotaisBlocosPorEstado(Estado estadoParametro);
        void AtualizarDashboard(Estado estadoParametro);
    }
}

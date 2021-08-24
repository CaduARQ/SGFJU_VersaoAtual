using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface DashboardRelatorioRepository : Repository<DashboardRelatorio>{
        IList<RelatorioTotaisGeralDTO> RetornaTotaisNacional();
        RelatorioTotaisGeralDTO RetornaRelatorioTotaisEstado(Estado estadoParametro);
        RelatorioTotaisGeralDTO RetornaRelatorioTotaisPorbloco(Bloco blocoParametro);
        IList<RelatorioBlocoTotaisGeraisDTO> RetornaTotaisBlocosPorEstado(Estado estadoParametro);
        void AtualizarDashboard(Estado estadoParametro);
    }
}

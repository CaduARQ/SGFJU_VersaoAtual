using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface AVDashboardRepository : Repository<Jovem>
    {
        IList<TotaisArvoreVidaEstadoDTO> ListaTotaisArvoreVidaGeral();
        TotaisArvoreVidaEstadoDTO ListaTotaisArvoreVidaPorEstado(EstadoDTO pEstadoDTO);
    }
}

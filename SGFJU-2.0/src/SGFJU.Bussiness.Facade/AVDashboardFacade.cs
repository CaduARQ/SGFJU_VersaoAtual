using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface AVDashboardFacade : Facade<Jovem>
    {
        IList<TotaisArvoreVidaEstadoDTO> ListaTotaisArvoreVidaGeral();
        TotaisArvoreVidaEstadoDTO ListaTotaisArvoreVidaPorEstado(EstadoDTO pEstadoDTO);
    }
}

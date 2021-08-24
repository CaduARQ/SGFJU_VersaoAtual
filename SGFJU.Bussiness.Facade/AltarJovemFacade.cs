using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface AltarJovemFacade : Facade<Jovem>
    {
        IList<AltarJovemDTO> ObterJovensAltarJovemPorParametro(AltarJovemParametroPesquisaDTO parametros);
        IList<AltarJovemDTO> ObterTodosBR();
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorEstado(EstadoDTO estado);
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorBloco(BlocoDTO bloco);
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemAgua();
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemOleo();
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemSal();
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemLuz();
    }
}

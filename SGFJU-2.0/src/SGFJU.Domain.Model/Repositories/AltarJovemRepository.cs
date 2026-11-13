using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface AltarJovemRepository : Repository<Jovem> {
        IList<AltarJovemDTO> ObterTodosBR();
        IList<AltarJovemDTO> ObterJovensAltarJovemPorParametro(AltarJovemParametroPesquisaDTO parametros);
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorEstado(Estado estado);
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemPorBloco(Bloco bloco);
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemAgua();
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemOleo();
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemSal();
        IList<AltarJovemDTO> ObterTodosJovensAltarJovemLuz();
        IList<TodosJovensDTO> ListaJovensLevantadosParaOAltarPorParametro(AltarJovemParametroPesquisaDTO parametrosPesquisa);
    }
}

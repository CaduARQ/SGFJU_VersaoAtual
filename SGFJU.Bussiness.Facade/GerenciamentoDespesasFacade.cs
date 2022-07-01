using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface GerenciamentoDespesasFacade : Facade<Despesa>
    {
        IList<DespesaDTO> ListarDespesasRegistradasHojePorEstado(EstadoDTO estadoDespesas = null);
        IList<DespesaDTO> ListaDespesasPorParametro(ParametroDespesasDTO parametrosPesquisa);
    }
}

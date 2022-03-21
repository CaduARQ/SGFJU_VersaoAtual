using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface PatrimonioRepository : Repository<ItemPatrimonio> {
        IList<ItemPatrimonioDTO> ListarPatrimonioPorParametro(ParametroPesquisaPatrimonioDTO parametros);
    }
}

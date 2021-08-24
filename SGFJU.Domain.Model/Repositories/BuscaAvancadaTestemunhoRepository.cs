using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface BuscaAvancadaTestemunhoRepository: Repository<Jovem> {
        IList<RetornoBuscaAvancadaDTO> BuscaAvancadaTestemunhoPorParametro(BuscaAvancadaParametroDTO parametrosBuscaAvancada);
    }
}

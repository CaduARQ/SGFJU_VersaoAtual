using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    interface BuscaAvancadaTestemunhoFacade : Facade<Jovem> {
        IList<RetornoBuscaAvancadaDTO> BuscaAvancadaTestemunhoPorParametro(BuscaAvancadaParametroDTO parametrosBuscaAvancada);
    }
}

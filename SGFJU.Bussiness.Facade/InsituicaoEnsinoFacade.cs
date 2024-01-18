using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface InsituicaoEnsinoFacade : Facade<InstituicaoEnsino>
    {
        IList<InstituicaoEnsinoDTO> ListarPorParametro(ParametroPesquisaInstituicaoEnsinoDTO parametroPesquisa);
    }
}

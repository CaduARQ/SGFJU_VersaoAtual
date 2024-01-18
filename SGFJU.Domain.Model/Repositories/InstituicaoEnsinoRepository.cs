using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface InstituicaoEnsinoRepository : Repository<InstituicaoEnsino>
    {
        IList<InstituicaoEnsinoDTO> ListarPorParametro(ParametroPesquisaInstituicaoEnsinoDTO parametroPesquisa);
        RespostaRequisicaoDTO ExcluirInstituicaoEnsino(InstituicaoEnsinoDTO instituicaoASerExcluida);        
    }
}

using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface EstadoFacade : Facade<Estado>
    {
        IList<Bloco> obterBlocosDoEstado(Estado estadoParametro);
        IList<RegiaoDTO> ObterRegioesPorEstado(Estado estadoParametro);
        IList<Regiao> obterRegioesDoBloco(Bloco blocoParametro);
        IList<Igreja> obterIgrejasDaRegiao(Regiao regiaoParametro);
        IList<IgrejaDTO> obterTodasIgrejasDoEstado(Estado estadoParametro);
        IList<IgrejaDTO> PesquisarIgrejasPorParametro(IgrejaDTO parametros);
        ResultadoExclusaoBlocoDTO PodeExcluirBloco(Bloco blogo);
        ResultadoExclusaoRegiaoDTO PodeExcluirRegiao(Regiao regiao);
        ResultadoExclusaoIgrejaDTO PodeExcluirIgreja(Igreja igreja);
        void ExcluirIgrejaDoEstado(Igreja igrejaParaExclusao);
        bool JaExisteIgrejaNaRegiao(IgrejaDTO igrejaAVerificar);
        IList<IgrejaCoordenadorDTO> RetornaInformacoesIgrejasEstado(Estado estadoParametro);
        bool IgrejaPossuiCoordenador(IgrejaCoordenador igrejaCoordenadorParametroB);
        bool TranfereIgrejaDeRegiao(IgrejaDTO igrejaASerTransferida, RegiaoDTO regiaoDestino);
        bool TranfereRegiaoDeBloco(RegiaoDTO regiaoASerTransferida, BlocoDTO blocoDestino);
    }
}

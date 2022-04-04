using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface EstadoRepository : Repository<Estado>
    {
        IList<Bloco> obterBlocosDoEstado(Estado estadoParametro);
        IList<RegiaoDTO> ObterRegioesPorEstado(Estado estadoParametro);
        IList<Regiao> obterRegioesDoBloco(Bloco blocoParametro);
        IList<Igreja> obterIgrejasDaRegiao(Regiao regiaoParametro);
        IList<Regiao> obterTodasRegioesDoEstado(Estado estadoParametro);
        IList<IgrejaDTO> obterTodasIgrejasDoEstado(Estado estadoParametro);
        IList<IgrejaDTO> PesquisarIgrejasPorParametro(IgrejaDTO parametros);
        ResultadoExclusaoBlocoDTO PodeExcluirBloco(Bloco blogo);
        ResultadoExclusaoRegiaoDTO PodeExcluirRegiao(Regiao regiao);
        ResultadoExclusaoIgrejaDTO PodeExcluirIgreja(Igreja igreja);
        void AtualizarBlocoDoEstado(BlocoDTO blocoParaAtualizacao);
        void ExcluirBlocoDoEstado(Bloco blocoParaExclusao);
        void AtualizarRegiaoDoEstado(RegiaoDTO regiaoParaAtualizacao);
        void ExcluirRegiaoDoEstado(Regiao regiaoParaExclusao);        
        void ExcluirIgrejaDoEstado(Igreja igrejaParaExclusao);
        bool JaExisteIgrejaNaRegiao(IgrejaDTO igrejaAVerificar);
        bool IgrejaPossuiCoordenador(IgrejaCoordenador igrejaCoordenadorParametro);
        IList<IgrejaCoordenadorDTO> RetornaInformacoesIgrejasEstado(Estado estadoParametro);
        void AtualizarIgreja(Igreja igrejaAAtualizar);
        bool TranfereIgrejaDeRegiao(IgrejaDTO igrejaASerTransferida, RegiaoDTO regiaoDestino);
        bool TranfereRegiaoDeBloco(RegiaoDTO regiaoASerTransferida, BlocoDTO blocoDestino);
    }
}

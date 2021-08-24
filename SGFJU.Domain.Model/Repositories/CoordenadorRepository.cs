using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Repositories
{
    public interface CoordenadorRepository {
        void RegistraCoordenador(IgrejaCoordenador novoCoordenador);
        void AssociaObreiroComoCoordenador(IgrejaCoordenador novoCoordenador);
        IList<IgrejaCoordenadorDTO> PesquisarCoordenadorPorParametro(IgrejaCoordenadorParametroDTO parametroPesquisaCoordenador);
        IList<IgrejaCoordenadorDTO> ListarCoordenadoresPorEstado(EstadoDTO estadoParametro);
        void AtualizarCoordenador(IgrejaCoordenador coordenadorParaAtualizacao);
        void TrocarCoordenador(IgrejaCoordenador coordenadorParaTrocar);
        IgrejaCoordenadorDTO ObterCoordenadorInformacoesDetalhadas(IgrejaCoordenadorDTO parametroPesquisaCoordenador);
        IgrejaCoordenador ObterIgrejaCoordenadorPorID(int idIgrejaCoordenador);
        void InformarIgrejaSemCoordenador(Igreja igrejaSemCoordenador);
        IList<IgrejaCoordenadorDTO> ObterPanoramaGeralCoordenadorPorEstado(EstadoDTO estadoParametro);
        IList<IgrejaCoordenadorDTO> ObterPanoramaGeralCoordenadorNacional();
    }
}

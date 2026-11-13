using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Bussiness.Facade
{
    public interface FacadeCoordenador {
        void RegistraCoordenador(IgrejaCoordenador novoCoordenador);
        void AssociaObreiroComoCoordenador(IgrejaCoordenador novoCoordenador);
        IList<IgrejaCoordenadorDTO> PesquisarCoordenadorPorParametro(IgrejaCoordenadorParametroDTO parametroPesquisaCoordenador);
        IList<IgrejaCoordenadorDTO> ListarCoordenadoresPorEstado(EstadoDTO estadoParametro);
        void AtualizarCoordenador(IgrejaCoordenador novoCoordenador);
        void TrocarCoordenador(IgrejaCoordenador coordenadorParaTrocar);
        IgrejaCoordenadorDTO ObterCoordenadorInformacoesDetalhadas(IgrejaCoordenadorDTO parametroCoordenador);
        IgrejaCoordenador ObterIgrejaCoordenadorPorID(int idIgrejaCoordenador);
        IList<IgrejaCoordenadorDTO> ObterPanoramaGeralCoordenadorPorEstado(EstadoDTO estadoParametro);
        IList<IgrejaCoordenadorDTO> ObterPanoramaGeralCoordenadorNacional();
    }
}

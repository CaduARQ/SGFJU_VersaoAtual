using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SGFJU.Api.Legado;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Infra.Util;
using SGFJU.ServicesLayer.DTO;

namespace SGFJU.Api.Controllers
{
    /// <summary>
    /// Consulta Geral da versão 2.0. Mesmos filtros da tela antiga (ConsultaGeral.html), mas:
    /// - as habilidades vêm no próprio pedido (a antiga guardava na sessão);
    /// - todo texto é validado/escapado antes de chegar ao SQL;
    /// - quem não é ADM só enxerga o próprio estado;
    /// - o resultado não repete o mesmo jovem.
    /// </summary>
    [ApiController]
    [Route("api/v2/jovens/consulta")]
    public class ConsultaGeralV2Controller : ControllerBase
    {
        public const int LIMITE = 5000;

        public sealed class Resultado
        {
            public int Total { get; set; }
            public bool Truncado { get; set; }
            public IList<TodosJovensDTO> Jovens { get; set; }
        }

        [HttpPost]
        public ActionResult<Resultado> Consultar([FromBody] ConsultaGeralDTO filtros)
        {
            filtros ??= new ConsultaGeralDTO();
            var usuario = SessionHelper.RetornaUsuarioLogado();
            int.TryParse(SgfjuConfig.Get("CodeADM"), out var codigoAdm);
            if (usuario?.PerfilUsuario?.Code != codigoAdm)
                filtros.IdEstado = usuario?.EstadoUsuario?.Id ?? -1;

            filtros.ParametrosHabilidade ??= new List<HabilidadeProjetoNivelDTO>();
            SqlSeguro.Sanitizar(filtros);

            var jovens = new FacadeJovemImpl().ListaJovensConsultaGeral(filtros)
                .GroupBy(j => j.IdJovem).Select(g => g.First())
                .ToList();

            return Ok(new Resultado
            {
                Total = jovens.Count,
                Truncado = jovens.Count > LIMITE,
                Jovens = jovens.Take(LIMITE).ToList()
            });
        }
    }
}

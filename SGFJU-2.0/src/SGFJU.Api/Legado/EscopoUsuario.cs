using SGFJU.Domain.Model.Infra.Util;

namespace SGFJU.Api.Legado
{
    /// <summary>
    /// Até onde o usuário logado pode ver/alterar: ADM vê tudo; secretaria de bloco fica no bloco;
    /// secretaria regional fica na região; os demais perfis ficam no próprio estado.
    /// Usado por todas as rotas 2.0 (as rotas antigas aceitavam ids de qualquer estado).
    /// </summary>
    public sealed class EscopoUsuario
    {
        private const int PERFIL_SECRETARIA_BLOCO = 7;
        private const int PERFIL_SECRETARIA_REGIONAL = 9;

        public bool EhAdm { get; private set; }
        public int IdEstado { get; private set; }
        public int IdBloco { get; private set; }
        public int IdRegiao { get; private set; }

        public static EscopoUsuario Atual()
        {
            var u = SessionHelper.RetornaUsuarioLogado();
            int.TryParse(SgfjuConfig.Get("CodeADM"), out var codigoAdm);
            var perfil = u?.PerfilUsuario?.Code ?? 0;
            return new EscopoUsuario
            {
                EhAdm = perfil == codigoAdm,
                IdEstado = u?.EstadoUsuario?.Id ?? -1,
                IdBloco = perfil == PERFIL_SECRETARIA_BLOCO ? u?.BlocoUsuario?.Id ?? -1 : 0,
                IdRegiao = perfil == PERFIL_SECRETARIA_REGIONAL ? u?.RegiaoUsuario?.Id ?? -1 : 0,
            };
        }

        public bool Permite(int idEstado, int idBloco, int idRegiao) =>
            EhAdm || (idEstado == IdEstado && (IdBloco == 0 || idBloco == IdBloco) && (IdRegiao == 0 || idRegiao == IdRegiao));

        /// <summary>Filtros efetivos: o escopo sempre prevalece sobre o que foi pedido (ADM pode escolher o estado).</summary>
        public (int estado, int bloco, int regiao) Aplicar(int idEstado, int idBloco, int idRegiao) =>
            (EhAdm ? idEstado : IdEstado, IdBloco != 0 ? IdBloco : idBloco, IdRegiao != 0 ? IdRegiao : idRegiao);
    }
}

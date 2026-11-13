// Menus por perfil, convertidos dos arquivos Serializeds/menu*.txt do sistema antigo.
// `href` aponta para a nova rota. Itens com `legado` ainda não foram migrados:
// a tela mostra o aviso "em migração" com o nome da página antiga.

import type { LucideIcon } from "lucide-react";
import {
  BarChart3,
  Building2,
  ClipboardList,
  GraduationCap,
  LayoutDashboard,
  Package,
  Search,
  Settings2,
  Shirt,
  TreePine,
  UserPlus,
  Users,
  CalendarDays,
} from "lucide-react";

export type MenuItem = { label: string; href: string; legado?: string; externo?: boolean };
export type MenuGrupo = { label: string; icon: LucideIcon; itens: MenuItem[] };

const emMigracao = (label: string, paginaAntiga: string): MenuItem => ({
  label,
  href: `/em-migracao?pagina=${encodeURIComponent(paginaAntiga)}&titulo=${encodeURIComponent(label)}`,
  legado: paginaAntiga,
});

// Perfis (PerfilUsuario.Code) usados no RMM do XController
export const PERFIS = {
  ADM: 4,
  PASTOR_ESTADUAL: 5,
  SECRETARIA_ESTADUAL: 6,
  SECRETARIA_BLOCO: 7,
  SECRETARIA_REGIONAL: 9,
  SECRETARIA_BR: 13,
  COORD_HELP: 14,
} as const;

const consultasSecretaria: MenuGrupo = {
  label: "Consultas",
  icon: Search,
  itens: [
    { label: "Todos os jovens", href: "/jovens" },
    emMigracao("Geral (parâmetros)", "ConsultaGeralParametros.html"),
    emMigracao("Autorizações de camisas", "GerenciaCamisasFJUEstado.html"),
    emMigracao("Testemunho", "BuscaEspecializadaTestemunho.html"),
  ],
};

const gerenciar: MenuGrupo = {
  label: "Gerenciar",
  icon: TreePine,
  itens: [
    { label: "Igrejas, blocos e regiões", href: "/estrutura" },
    { label: "Usuários", href: "/usuarios" },
    emMigracao("Coordenadores", "GerenciaCoordenadoresEstado.html"),
    emMigracao("Panorama do estado", "GerenciaCoordPanoramaEstado.html"),
    emMigracao("Associar jovens (Árvore da Vida)", "GerenciaArvoreDaVidaEstadual.html"),
    emMigracao("Desassociar jovens", "GerenciaArvoreVidaObreirosAssociacoes.html"),
    emMigracao("Obreiros", "GerenciaArvoreVidaObreiros.html"),
    emMigracao("Em acompanhamento", "GerenciaAVJovensEmAcompanhamento.html"),
  ],
};

const voluntarios: MenuGrupo = {
  label: "Voluntários",
  icon: UserPlus,
  itens: [emMigracao("Novo jovem", "RegistraJovem.aspx")],
};

const relatorios: MenuGrupo = {
  label: "Relatórios",
  icon: ClipboardList,
  itens: [emMigracao("Gerenciar relatórios FJU", "GerenciaRelatoriosFJU.html")],
};

const patrimonio: MenuGrupo = {
  label: "Patrimônio",
  icon: Package,
  itens: [emMigracao("Consultar patrimônio", "ConsultarPatrimonio.html"), emMigracao("Cadastrar patrimônio", "RegistrarPatrimonio.aspx")],
};

const help = (registrar: boolean): MenuGrupo => ({
  label: "Help",
  icon: GraduationCap,
  itens: [
    ...(registrar ? [emMigracao("Registrar instituições", "RegistraInstituicaoEnsino.html")] : []),
    emMigracao("Pesquisar instituições", registrar ? "GerenciarInstituicaoEnsino.html" : "GerenciarInstituicaoEnsinoNacional.html"),
  ],
});

export function menuDoPerfil(codigoPerfil: number): MenuGrupo[] {
  switch (codigoPerfil) {
    case PERFIS.ADM:
      return [
        {
          label: "Dashboard",
          icon: LayoutDashboard,
          itens: [
            { label: "Nacional", href: "/dashboard/nacional" },
            emMigracao("Árvore da Vida", "DashboardArvoreVidaNacional.html"),
            emMigracao("Camisas FJU", "DashboardNacionalCamisasFJU.html"),
          ],
        },
        {
          label: "Consultas",
          icon: BarChart3,
          itens: [
            { label: "Todos os jovens", href: "/jovens" },
            emMigracao("Geral", "ConsultaGeral.html"),
            emMigracao("Altar Jovem", "GerenciaNacionalAltarJovem.html"),
            emMigracao("Jovens levantados no altar", "ListaJovensLevantadosAltar.html"),
          ],
        },
        { label: "Gerenciar", icon: Building2, itens: [{ label: "Igrejas, blocos e regiões", href: "/estrutura" }, { label: "Usuários", href: "/usuarios" }] },
        help(false),
        { label: "Eventos", icon: CalendarDays, itens: [{ label: "Eventos FJU", href: "http://fjuoficial.org/eventos", externo: true }] },
      ];
    case PERFIS.PASTOR_ESTADUAL:
      return [
        { label: "Dashboard", icon: LayoutDashboard, itens: [{ label: "Estadual", href: "/dashboard/estadual" }] },
        voluntarios,
        {
          label: "Consultas",
          icon: Search,
          itens: [
            { label: "Todos os jovens", href: "/jovens" },
            emMigracao("Geral", "ConsultaGeralEstadual.html"),
            emMigracao("Autorizações de camisas", "GerenciaCamisasFJUEstado.html"),
            emMigracao("Testemunho", "BuscaEspecializadaTestemunho.html"),
          ],
        },
        gerenciar,
      ];
    case PERFIS.SECRETARIA_ESTADUAL:
      return [
        voluntarios,
        { label: "Altar", icon: Users, itens: [emMigracao("Levantados", "ListaJovensLevantadosAltar.html")] },
        relatorios,
        help(true),
        consultasSecretaria,
        patrimonio,
        gerenciar,
      ];
    case PERFIS.SECRETARIA_BLOCO:
    case PERFIS.SECRETARIA_REGIONAL:
      return [voluntarios, relatorios, consultasSecretaria, patrimonio, gerenciar];
    case PERFIS.SECRETARIA_BR:
      return [{ label: "Painel de controle", icon: Settings2, itens: [emMigracao("Painel", "PainelControle.html")] }];
    case PERFIS.COORD_HELP:
      return [help(true)];
    default:
      return [{ label: "Consultas", icon: Shirt, itens: [{ label: "Todos os jovens", href: "/jovens" }] }];
  }
}

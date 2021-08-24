using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SGFJU.UI.Views
{
    public partial class formInformacoesAdicionaisEsporte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){}

        protected void btnAdicionaInformacoesProjeto_Click(object sender, EventArgs e) {
            AdicionaInformacoesHabilidadesJovem();
            if (TemHabilidadesArtesMarciais())
                AssociaJovemDepartamentoArtesMarciais();
        }
        private bool TemHabilidadesArtesMarciais() {
            if (rbNivelBoxe.SelectedIndex                         != -1 ||
                rbNivelCapoeira.SelectedIndex                     != -1 ||
                rbNivelJiuJitsu.SelectedIndex                     != -1 ||
                rbNivelMuayThay.SelectedIndex                     != -1 ||
                rbNivelTaekwondo.SelectedIndex                    != -1 ||
                rbNivelHabilidadeExtraInstrumentos0.SelectedIndex != -1)
                return true;
            return false;
        }
        private void AssociaJovemDepartamentoArtesMarciais(){
            var departamentosJovemEstaAssociado = new List<DepartamentoProjeto>();
            int codigoDepartamentoArtesMarciais = 0;
            var departamentosDoProjetoEsporte = (Session["DepartamentosProjeto"] as List<DepartamentoProjetoDTO>)
                                                    .Where(t => string.Equals(t.NomeProjeto, "Esporte", StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var departamento in departamentosDoProjetoEsporte){
                if (string.Equals(departamento.NomeDepartamento, "ArtesMarciais"))
                    codigoDepartamentoArtesMarciais = departamento.IdDepartamento;
            }

            if (Session["DepartamentosAosQuaisJovemEstaLigado"] != null) {
                var departamentoJaFoiAdicionado = 
                    ((Session["DepartamentosAosQuaisJovemEstaLigado"] as List<DepartamentoProjeto>).Where(t => t.Code == codigoDepartamentoArtesMarciais).Count() > 0);
                if(!departamentoJaFoiAdicionado)
                    (Session["DepartamentosAosQuaisJovemEstaLigado"] as List<DepartamentoProjeto>)
                        .Add(new DepartamentoProjeto { Code = codigoDepartamentoArtesMarciais });
            }
            else {
                departamentosJovemEstaAssociado.Add(new DepartamentoProjeto { Code = codigoDepartamentoArtesMarciais });
                Session.Add("DepartamentosAosQuaisJovemEstaLigado", departamentosJovemEstaAssociado);
            }
        }
        private void AdicionaInformacoesHabilidadesJovem() {
            var controlesDaPagina = this.Form.Controls;
            var habilidadesSelecionadasPeloJovem = new List<HabilidadeProjetoDTO>();
            var habilidadesQueOJovemPossui = new List<JovemHabilidadeProjeto>();
            foreach (var controle in controlesDaPagina)
            {
                if (controle.GetType().Name.Contains("RadRadioButtonList"))
                {
                    foreach (ButtonListItem itemRadio in (controle as RadRadioButtonList).Items)
                    {
                        if (itemRadio.Selected)
                        {
                            var clientIDContendoNomeHabilidade = (controle as RadRadioButtonList).ClientID;
                            var codigoNivel = RetornaIndiceNivelSelecionadoHabilidade((controle as RadRadioButtonList).SelectedIndex);
                            if (clientIDContendoNomeHabilidade.Contains("Extra"))
                            {
                                var nomeHabilidadeExtra = (clientIDContendoNomeHabilidade.Contains("Marcial")) ?
                                                             txtHabilidadeExtraArteMarcial.Text : txtHabilidadeExtraEsporte.Text;
                                habilidadesQueOJovemPossui.Add(new JovemHabilidadeProjeto
                                {
                                    Habilidade = new HabilidadeProjeto { NomeHabilidade = nomeHabilidadeExtra },
                                    Nivel = new Nivel { Code = codigoNivel }
                                });
                            }
                            else
                            {
                                //var codigoHabilidadeSeleionada = RetornaCodigoHabilidade(clientIDContendoNomeHabilidade);
                                var codigoHabilidadeSeleionada = RetornaCodigoHabilidade2(clientIDContendoNomeHabilidade);
                                if(!habilidadeJaFoiAdicionada(codigoHabilidadeSeleionada))
                                    habilidadesQueOJovemPossui.Add(new JovemHabilidadeProjeto
                                    {
                                        Habilidade = new HabilidadeProjeto { Code = codigoHabilidadeSeleionada },
                                        Nivel = new Nivel { Code = codigoNivel }
                                    });
                                //habilidadesQueOJovemPossui.Add(new JovemHabilidadeProjeto
                                //{
                                //    Habilidade = new HabilidadeProjeto { Code = codigoHabilidadeSeleionada },
                                //    Nivel = new Nivel { Code = codigoNivel }
                                //});
                            }
                        }
                    }
                }
            }
            if (habilidadesQueOJovemPossui.Count == 0)
                rwin.RadAlert("Nõa há habilidades selecioonadas para adicionar!!!", 200, 100, "Validação", null);
            else
            {
                if (Session["HabilidadesQueOJovemPossui"] != null)
                {
                    foreach (var habilidade in habilidadesQueOJovemPossui)
                    {
                        (Session["HabilidadesQueOJovemPossui"] as IList<JovemHabilidadeProjeto>).Add(habilidade);
                    }
                }
                else
                {
                    Session.Add("HabilidadesQueOJovemPossui", habilidadesQueOJovemPossui);
                    string script = "function f(){CloseWindow(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
                }
            }
        }
        private bool habilidadeJaFoiAdicionada(int codigoHabilidadeSeleionada){
            bool habilidadeJaFoiAdicionada = false;
            if (Session["HabilidadesQueOJovemPossui"] == null)
                return false;
            else {
                if (Session["HabilidadesQueOJovemPossui"] != null)
                    habilidadeJaFoiAdicionada = ((Session["HabilidadesQueOJovemPossui"] as IList<JovemHabilidadeProjeto>).Where(t => t.Habilidade.Code == codigoHabilidadeSeleionada).Count() > 0);
            }
            return habilidadeJaFoiAdicionada;
        }
        private int RetornaIndiceNivelSelecionadoHabilidade(int indiceSelecionado)
        {
            var todosNiveis = (Session["TodosNiveis"] as IList<Nivel>);
            var codigoNivelRetorno = -1;
            switch (indiceSelecionado)
            {
                case 0:
                    codigoNivelRetorno =  todosNiveis.Where(t => t.Descricao == "Bom").ToList()[0].Code;
                    break;
                case 1:
                    codigoNivelRetorno = todosNiveis.Where(t => t.Descricao == "Regular").ToList()[0].Code;
                    break;
                case 2:
                    codigoNivelRetorno = todosNiveis.Where(t => t.Descricao == "Excelente").ToList()[0].Code;
                    break;
            }
            return codigoNivelRetorno;
        }
        private int RetornaCodigoHabilidade(string clientIDContendoNomeHabilidade) {
            var habilidadesProjetoEsporte = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Esporte");
            var nomeHabilidadeFormatado = clientIDContendoNomeHabilidade.Substring(7);
            var codigoHabilidade = habilidadesProjetoEsporte.Where(t => t.NomeHabilidade == nomeHabilidadeFormatado).Single().IdHabilidade;
            return codigoHabilidade;
        }
        private int RetornaCodigoHabilidade2(string clientIDContendoNomeHabilidade) {
            var habilidadesProjetoEsporte = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Esporte");
            var nomeHabilidadeFormatado = clientIDContendoNomeHabilidade.Substring(7);
            foreach (var habilidadeProjeto in habilidadesProjetoEsporte) {
                if (string.Equals(habilidadeProjeto.NomeHabilidade, nomeHabilidadeFormatado, StringComparison.OrdinalIgnoreCase)) {
                    return habilidadeProjeto.IdHabilidade;
                }
            }
            return 0;
        }
    }
}
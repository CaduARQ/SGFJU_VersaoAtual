using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SGFJU.UI.Views
{
    public partial class formInformacoesAdicionaisCultura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
            if (!Page.IsPostBack) {
                CarregaDepartamentosProjetoCultura();
                CarregaTonsVoz();
            }
        }

        private void CarregaTonsVoz() {
            var tonsParametro = new string[]{"Tenor", "Baritono", "TonBaixo", "Soprano", "MezzoSoprano", "Contralto" };
            var tonsDeVoz = (Session["TodasHabilidades"] as List<HabilidadeProjetoDTO>)
                                            .Where(t => t.NomeProjeto == "Cultura" &&
                                                   tonsParametro.Contains(t.NomeHabilidade)).ToList();
            foreach (var habilidadeTon in tonsDeVoz) {
                rbClassificacaoVocal.Items.Add(new ButtonListItem { Text = habilidadeTon.NomeHabilidade, Value = habilidadeTon.IdHabilidade.ToString() });
            }
        }

        private void CarregaHabilidadesCultura()
        {            
            var habilidadesCultura = (Session["TodasHabilidades"] as List<HabilidadeProjetoDTO>)
                                            .Where(t => t.NomeProjeto == "Cultura").ToList();
        }

        private void CarregaDepartamentosProjetoCultura()
        {
            var departamentosCultura = (Session["DepartamentosProjeto"] as List<DepartamentoProjetoDTO>)
                                            .Where(t => t.NomeProjeto == "Cultura").ToList();
            foreach (var departamento in departamentosCultura) {
                chkDepartamentosCultura.Items.Add(new ButtonListItem { 
                    Text = departamento.NomeDepartamento,
                    Value = departamento.IdDepartamento.ToString()
                });
            }
        }
        protected void btnAdicionaInformacoesProjeto_Click(object sender, EventArgs e)
        {
            if(chkDepartamentosCultura.SelectedItems.Count > 0)
                AdicionaDepartamentosJovemEstaLigado();
            AdicionaHabilidadesDoJovem();
            if(!string.IsNullOrEmpty(txtCursoRelacionadoProjetoCultura.Text))
                AdicionaCursoAdicionalLigadosAoProjeto();
            //if (rbClassificacaoVocal.SelectedIndex != -1)
            //    AdicionaHabilidadeClassificacaoVocal(new HabilidadeProjetoDTO { IdHabilidade = int.Parse(rbClassificacaoVocal.SelectedValue) });
            string script = "function f(){CloseWindow(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        private void AdicionaHabilidadeClassificacaoVocal(HabilidadeProjetoDTO classificacaoVocalParametro){
            var classificacaoVocal = new List<JovemHabilidadeProjeto>();
            if (Session["HabilidadesQueOJovemPossui"] != null){
                (Session["HabilidadesQueOJovemPossui"] as IList<JovemHabilidadeProjeto>)
                    .Add(new JovemHabilidadeProjeto {
                        Habilidade = new HabilidadeProjeto { Code = classificacaoVocalParametro.IdHabilidade }
                    });
            }
            else {
                classificacaoVocal.Add(new JovemHabilidadeProjeto
                {
                    Habilidade = new HabilidadeProjeto
                    {
                        Code = classificacaoVocalParametro.IdHabilidade
                    }
                });
                Session.Add("HabilidadesQueOJovemPossui", classificacaoVocal);
            }
        }
        private void AdicionaDepartamentosJovemEstaLigado() {
            var departamentoAosQuaisJovemEstaLigado = new List<DepartamentoProjeto>();
            foreach (ButtonListItem chkItem in chkDepartamentosCultura.Items){
                if (chkItem.Selected) {
                    if (Session["DepartamentosAosQuaisJovemEstaLigado"] != null) {
                        var departamentoJaFoiAdicionado =
                                ((Session["DepartamentosAosQuaisJovemEstaLigado"] as List<DepartamentoProjeto>).Where(t => t.Code == int.Parse(chkItem.Value)).Count() > 0);
                        if (!departamentoJaFoiAdicionado)
                            (Session["DepartamentosAosQuaisJovemEstaLigado"] as List<DepartamentoProjeto>).Add(new DepartamentoProjeto
                            {
                                Code = int.Parse(chkItem.Value)
                            });
                    }
                    else
                        departamentoAosQuaisJovemEstaLigado.Add(new DepartamentoProjeto { 
                            Code = int.Parse(chkItem.Value)
                        });
                }
            }
            if (Session["DepartamentosAosQuaisJovemEstaLigado"] == null)
                Session.Add("DepartamentosAosQuaisJovemEstaLigado", departamentoAosQuaisJovemEstaLigado);
        }
        private void AdicionaHabilidadesDoJovem()
        {
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
                                var nomeHabilidadeExtraBanda = (clientIDContendoNomeHabilidade.Contains("ExtraInstrumentos")) ?
                                                             txtHabilidadeExtraInstrumento.Text : "";
                                var nomeHabilidadeExtraDanca = (clientIDContendoNomeHabilidade.Contains("ExtraDanca")) ?
                                                             txtHabilidadeExtraDanca.Text : "";
                                if (!string.IsNullOrEmpty(nomeHabilidadeExtraBanda))
                                    habilidadesQueOJovemPossui.Add(new JovemHabilidadeProjeto
                                    {
                                        Habilidade = new HabilidadeProjeto { NomeHabilidade = nomeHabilidadeExtraBanda },
                                        Nivel = new Nivel { Code = codigoNivel }
                                    });
                                if (!string.IsNullOrEmpty(nomeHabilidadeExtraDanca))
                                    habilidadesQueOJovemPossui.Add(new JovemHabilidadeProjeto
                                    {
                                        Habilidade = new HabilidadeProjeto { NomeHabilidade = nomeHabilidadeExtraDanca },
                                        Nivel = new Nivel { Code = codigoNivel }
                                    });
                            }
                            else if (clientIDContendoNomeHabilidade.Contains("Vocal")) {                                
                                var codigoHabilidadeSeleionada = int.Parse(rbClassificacaoVocal.SelectedValue);
                                codigoNivel = RetornaIndiceNivelSelecionadoHabilidade(0);
                                if (!habilidadeJaFoiAdicionada(codigoHabilidadeSeleionada))
                                    habilidadesQueOJovemPossui.Add(new JovemHabilidadeProjeto
                                    {
                                        Habilidade = new HabilidadeProjeto { Code = codigoHabilidadeSeleionada },
                                        Nivel = new Nivel { Code = codigoNivel }
                                    });
                            }
                            else {
                                //var codigoHabilidadeSeleionada = RetornaCodigoHabilidade(clientIDContendoNomeHabilidade); // teste
                                var codigoHabilidadeSeleionada = RetornaCodigoHabilidade2(clientIDContendoNomeHabilidade);                                
                                if (!habilidadeJaFoiAdicionada(codigoHabilidadeSeleionada))
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
                    Session.Add("HabilidadesQueOJovemPossui", habilidadesQueOJovemPossui);
            }
        }
        private bool habilidadeJaFoiAdicionada(int codigoHabilidadeSeleionada) {
            bool habilidadeJaFoiAdicionada = false;
            if (Session["HabilidadesQueOJovemPossui"] == null)
                return false;
            else {
                if (Session["HabilidadesQueOJovemPossui"] != null)
                    habilidadeJaFoiAdicionada = ((Session["HabilidadesQueOJovemPossui"] as IList<JovemHabilidadeProjeto>).Where(t => t.Habilidade.Code == codigoHabilidadeSeleionada).Count() > 0);
            }
            return habilidadeJaFoiAdicionada;
        }
        private void AdicionaCursoAdicionalLigadosAoProjeto()
        {
            var cursosAdicionaisProjeto = new List<CursoRelacionadoProjeto>();
            if (Session["CursosAdicionaisJovem"] != null) {
                (Session["CursosAdicionaisJovem"] as List<CursoRelacionadoProjeto>).Add(new CursoRelacionadoProjeto { 
                    NomeCurso = txtCursoRelacionadoProjetoCultura.Text,
                    ProjetoRelacionado = new Projeto { 
                        Code = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Cultura").ToList()[0].IdProjeto
                    }
                });
            }
            else {
                cursosAdicionaisProjeto.Add(new CursoRelacionadoProjeto { 
                    NomeCurso = txtCursoRelacionadoProjetoCultura.Text,
                    ProjetoRelacionado = new Projeto {
                        Code = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Cultura").ToList()[0].IdProjeto
                    }
                });
                Session.Add("CursosAdicionaisJovem", cursosAdicionaisProjeto);
            }
        }
        private int RetornaIndiceNivelSelecionadoHabilidade(int indiceSelecionado)
        {
            var todosNiveis = (Session["TodosNiveis"] as IList<Nivel>);
            var codigoNivelRetorno = -1;
            switch (indiceSelecionado)
            {
                case 0:
                    codigoNivelRetorno = todosNiveis.Where(t => t.Descricao == "Bom").ToList()[0].Code;
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
        private int RetornaCodigoHabilidade(string clientIDContendoNomeHabilidade)
        {
            var habilidadesProjetoCultura = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Cultura");
            var nomeHabilidadeFormatado = clientIDContendoNomeHabilidade.Substring(7);
            var codigoHabilidade = habilidadesProjetoCultura.Where(t => t.NomeHabilidade == nomeHabilidadeFormatado).Single().IdHabilidade;
            return codigoHabilidade;
        }
        private int RetornaCodigoHabilidade2(string clientIDContendoNomeHabilidade) {
            var habilidadesProjetoCultura = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Cultura");
            var nomeHabilidadeFormatado = clientIDContendoNomeHabilidade.Substring(7);
            int codigoHabilidade = 0;
            foreach (var habilidade in habilidadesProjetoCultura) {
                if (string.Equals(nomeHabilidadeFormatado, habilidade.NomeHabilidade, StringComparison.OrdinalIgnoreCase))
                    codigoHabilidade = habilidade.IdHabilidade;
            }
            //var codigoHabilidade = habilidadesProjetoCultura.Where(t => t.NomeHabilidade == nomeHabilidadeFormatado).Single().IdHabilidade;
            return codigoHabilidade;
        }
        protected void rbDepartamentosCultura_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = sender;
        }
    }
}
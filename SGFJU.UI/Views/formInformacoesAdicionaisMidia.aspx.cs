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
    public partial class formInformacoesAdicionaisMidia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){
        }
        protected void btnAdicionaInformacoesProjeto_Click(object sender, EventArgs e) {
            AdicionaHabilidadesDoJovem();
            if(!string.IsNullOrEmpty(txtCursoExtraProjetoMidia.Text))
                AdicionaCursoAdicionalLigadosAoProjeto();
            string script = "function f(){CloseWindow(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        private void AdicionaHabilidadesDoJovem() {
            var controlesDaPagina = this.Form.Controls;
            var habilidadesSelecionadasPeloJovem = new List<HabilidadeProjetoDTO>();
            var habilidadesQueOJovemPossui = new List<JovemHabilidadeProjeto>();
            foreach (var controle in controlesDaPagina)
            {
                if (controle.GetType().Name.Contains("RadRadioButtonList"))
                {
                    foreach (ButtonListItem itemRadio in (controle as RadRadioButtonList).Items)
                    {
                        if (itemRadio.Selected) {
                            var clientIDContendoNomeHabilidade = (controle as RadRadioButtonList).ClientID;
                            var codigoNivel = RetornaIndiceNivelSelecionadoHabilidade((controle as RadRadioButtonList).SelectedIndex);
                            if (clientIDContendoNomeHabilidade.Contains("Extra")) {
                                if(!string.IsNullOrEmpty(txtHabilidadeExtraMidia.Text))
                                    habilidadesQueOJovemPossui.Add(new JovemHabilidadeProjeto
                                    {
                                        Habilidade = new HabilidadeProjeto { NomeHabilidade = txtHabilidadeExtraMidia.Text },
                                        Nivel = new Nivel { Code = codigoNivel }
                                    });
                            }
                            else {
                                var nomeDepartamentoFormatado = clientIDContendoNomeHabilidade.Substring(7);
                                //AdicionaDepartamentosJovemEstaLigado(nomeDepartamentoFormatado);
                                AdicionaDepartamentosJovemEstaLigado2(nomeDepartamentoFormatado);
                                //var codigoHabilidadeSeleionada = RetornaCodigoHabilidade(clientIDContendoNomeHabilidade);
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
                if (Session["HabilidadesQueOJovemPossui"] != null) {
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
            else
            {
                if (Session["HabilidadesQueOJovemPossui"] != null)
                    habilidadeJaFoiAdicionada = ((Session["HabilidadesQueOJovemPossui"] as IList<JovemHabilidadeProjeto>).Where(t => t.Habilidade.Code == codigoHabilidadeSeleionada).Count() > 0);
            }
            return habilidadeJaFoiAdicionada;
        }

        private void AdicionaDepartamentosJovemEstaLigado(string nomeDepartamento)
        {
            var codigoDepartamento = (Session["DepartamentosProjeto"] as List<DepartamentoProjetoDTO>)
                                            .Where(t => t.NomeProjeto == "Midía" && 
                                                        t.NomeDepartamento.Equals(nomeDepartamento)).ToList()[0].IdDepartamento;
            var departamentosJovemEstaAssociado = new List<DepartamentoProjeto>();
            if (Session["DepartamentosAosQuaisJovemEstaLigado"] != null)
                (Session["DepartamentosAosQuaisJovemEstaLigado"] as List<DepartamentoProjeto>)
                    .Add(new DepartamentoProjeto { Code = codigoDepartamento });
            else {
                departamentosJovemEstaAssociado.Add(new DepartamentoProjeto { Code = codigoDepartamento });
                Session.Add("DepartamentosAosQuaisJovemEstaLigado", departamentosJovemEstaAssociado);
            }
        }
        private void AdicionaDepartamentosJovemEstaLigado2(string nomeDepartamento) {
            var departamentosJovemEstaAssociado = new List<DepartamentoProjeto>();
            var codigoDepartamento = this.retornaCodigodepartamento(nomeDepartamento);
            if (Session["DepartamentosAosQuaisJovemEstaLigado"] != null) {
                var departamentoJaFoiAdicionado =
                                ((Session["DepartamentosAosQuaisJovemEstaLigado"] as List<DepartamentoProjeto>).Where(t => t.Code == codigoDepartamento).Count() > 0);
                if (!departamentoJaFoiAdicionado)
                    (Session["DepartamentosAosQuaisJovemEstaLigado"] as List<DepartamentoProjeto>)
                        .Add(new DepartamentoProjeto { Code = codigoDepartamento });
            }
            else
            {
                departamentosJovemEstaAssociado.Add(new DepartamentoProjeto { Code = codigoDepartamento });
                Session.Add("DepartamentosAosQuaisJovemEstaLigado", departamentosJovemEstaAssociado);
            }
        }
        private int retornaCodigodepartamento(string nomeDepartamentoParametro) {            
            int codigoDepartamentoRetorno = 0;
            var departamentosDoProjetoMidia = (Session["DepartamentosProjeto"] as List<DepartamentoProjetoDTO>)
                                                    .Where(t => t.NomeProjeto == "Midía").ToList();
            foreach (var departamento in departamentosDoProjetoMidia){
                if (string.Equals(departamento.NomeDepartamento, nomeDepartamentoParametro, StringComparison.OrdinalIgnoreCase))
                    return departamento.IdDepartamento;
            }
            return codigoDepartamentoRetorno;
        }
        private void AdicionaCursoAdicionalLigadosAoProjeto()
        {
            if (Session["CursosAdicionaisJovem"] != null)
                (Session["CursosAdicionaisJovem"] as List<CursoRelacionadoProjeto>).Add(new CursoRelacionadoProjeto
                {
                    NomeCurso = txtCursoExtraProjetoMidia.Text,
                    ProjetoRelacionado = new Projeto { 
                        Code = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Midía").ToList()[0].IdProjeto
                    }
                });
            else {
                var cursosAdicionaisProjeto = new List<CursoRelacionadoProjeto>();
                cursosAdicionaisProjeto.Add(new CursoRelacionadoProjeto { 
                    NomeCurso = txtCursoExtraProjetoMidia.Text,
                    ProjetoRelacionado = new Projeto {
                        Code = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Midía").ToList()[0].IdProjeto
                    }
                });
                Session.Add("CursosAdicionaisJovem", cursosAdicionaisProjeto);
            }
        }
        private int RetornaCodigoHabilidade(string clientIDContendoNomeHabilidade)
        {
            var habilidadesProjetoMidia = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Midía");
            var nomeHabilidadeFormatado = clientIDContendoNomeHabilidade.Substring(7);
            var codigoHabilidade = habilidadesProjetoMidia.Where(t => t.NomeHabilidade == nomeHabilidadeFormatado).Single().IdHabilidade;
            return codigoHabilidade;
        }
        private int RetornaCodigoHabilidade2(string clientIDContendoNomeHabilidade)
        {
            var habilidadesProjetoMidia = (Session["TodasHabilidades"] as IList<HabilidadeProjetoDTO>).Where(t => t.NomeProjeto == "Midía");
            var nomeHabilidadeFormatado = clientIDContendoNomeHabilidade.Substring(7);
            int codigoHabilidade = 0;
            //var codigoHabilidade = habilidadesProjetoMidia.Where(t => t.NomeHabilidade == nomeHabilidadeFormatado).Single().IdHabilidade;
            foreach (var habilidade in habilidadesProjetoMidia) {
                if (string.Equals(habilidade.NomeHabilidade, nomeHabilidadeFormatado, StringComparison.OrdinalIgnoreCase))
                    codigoHabilidade = habilidade.IdHabilidade;
            }
            return codigoHabilidade;
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
    }
}
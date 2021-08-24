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
    public partial class formInformacoesAdicionaisProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ArmazenaNomeProjetoSessao(Request.QueryString["nomeProjeto"]);
        }

        private void ArmazenaNomeProjetoSessao(string projeto)
        {
            Session.Add("NomeProjeto", projeto);
        }

        protected void btnAdicionaInformacoesProjeto_Click(object sender, EventArgs e)
        {
            AdicionaCursoAdicionalLigadosAoProjeto();
            string script = "function f(){CloseWindow(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
        private void AdicionaCursoAdicionalLigadosAoProjeto()
        {            
            var cursosAdicionaisProjeto = new List<CursoRelacionadoProjeto>();
            var codigoProjeto = (Session["TodosProjetosFJU"] as List<ProjetoDTO>)
                                .Where(t => t.NomeProjeto.Equals(Session["NomeProjeto"]))
                                .Single<ProjetoDTO>().IdProjeto;
            var nomeCursoAdicional = (!string.IsNullOrEmpty(txtCursoExtraUF.Text))?
                                        txtCursoExtraUF.Text:txtNomeCursoAdicionaoProjeto.Text;
            if (Session["CursosAdicionaisJovem"] != null) {
                (Session["CursosAdicionaisJovem"] as List<CursoRelacionadoProjeto>)
                        .Add(new CursoRelacionadoProjeto
                        {
                            NomeCurso = nomeCursoAdicional,
                            ProjetoRelacionado = new Projeto { Code = codigoProjeto }
                        });
                if(chkCursosExtraUF.Items[0].Selected)
                    (Session["CursosAdicionaisJovem"] as List<CursoRelacionadoProjeto>)
                        .Add(new CursoRelacionadoProjeto
                        {
                            NomeCurso = "Noções de primeiros socorros",
                            ProjetoRelacionado = new Projeto { Code = codigoProjeto }
                        });
                if (chkCursosExtraUF.Items[1].Selected)
                    (Session["CursosAdicionaisJovem"] as List<CursoRelacionadoProjeto>)
                        .Add(new CursoRelacionadoProjeto
                        {
                            NomeCurso = "Primeiros Socorros avançado",
                            ProjetoRelacionado = new Projeto { Code = codigoProjeto }
                        });
            }
            else {
                cursosAdicionaisProjeto.Add(new CursoRelacionadoProjeto
                {
                    NomeCurso = txtNomeCursoAdicionaoProjeto.Text,
                    ProjetoRelacionado = new Projeto { Code = codigoProjeto }
                });
                if (chkCursosExtraUF.Items[0].Selected)
                    cursosAdicionaisProjeto.Add(new CursoRelacionadoProjeto
                                            {
                                                NomeCurso = "Noções de primeiros socorros",
                                                ProjetoRelacionado = new Projeto { Code = codigoProjeto }
                                            });
                if (chkCursosExtraUF.Items[1].Selected)
                    cursosAdicionaisProjeto.Add(new CursoRelacionadoProjeto
                                            {
                                                NomeCurso = "Primeiros Socorros avançado",
                                                ProjetoRelacionado = new Projeto { Code = codigoProjeto }
                                            });
                Session.Add("CursosAdicionaisJovem", cursosAdicionaisProjeto);
            }
        }
    }
}
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class formInformacoesAdicionaisUniversitarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                PreencheControleModalidadeEnsinoSuperior();
            }
        }
        private void PreencheControleModalidadeEnsinoSuperior()
        {
            var facade = new FacadeBaseImpl<Estado>();
            var modalidadesEnsinoSuperior = facade.ListAllValueObjects<ModalidadeEnsinoSuperior>();
            foreach (var modalidade in modalidadesEnsinoSuperior)
            {
                rbModalidadeNivelSuperior.Items
                    .Add(new Telerik.Web.UI.ButtonListItem { Value = modalidade.Code.ToString(), Text = modalidade.Descricao });
            }
        }

        protected void btnAdicionaInformacoesProjeto_Click(object sender, EventArgs e)
        {
            var dadosEducacionais = new DadosEducacionais { 
                DesejaCursarNivelSuperior = (rbDesejaCursarNivelSuperior.SelectedIndex == 0)?'S':'N',
                NomeCursoSuperior = txtNomeCursoFaculdadeJovem.Text,
                PossuiNivelSuperior = (rbJaSeFormou.SelectedIndex == 0)?'S':'N',
                PeriodoAtualNivelFaculdade = txtPeriodoCursando.Text,
                PrevisaoConclusaoCurso = txtPrevisaoFormatura.Text,
                ModalidadeCursadaEnsinoSuperior = (rbModalidadeNivelSuperior.SelectedIndex != -1) ?new ModalidadeEnsinoSuperior { Code = int.Parse(rbModalidadeNivelSuperior.SelectedValue) } : null 
            };
            Session.Add("InformacoesNivelSuperiorJovem", dadosEducacionais);
            string script = "function f(){CloseWindow(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class frmCorrigeErros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CarregaDadosJovem(Request.QueryString["IdJovem"]);
        }
        private void CarregaDadosJovem(string idJovem)
        {
            var jovem = (Session["TodosJovens"] as IList<TodosJovensDTO>).Where(j => j.IdJovem == int.Parse(idJovem)).FirstOrDefault();
            lblNomeJovem.Text = jovem.NomeJovem;
            Session.Add("jovemAAtualizar", jovem);
        }
        
        protected void btnAtualizaInformacoesJovem_Click(object sender, EventArgs e)
        {
            var facade = new FacadeJovemImpl();
            var jovem = facade.GetByID((Session["jovemAAtualizar"] as TodosJovensDTO).IdJovem);
            var testemunhoJovem = facade.ObterTestemunhoDoJovem(new Jovem { Id = jovem.Id });

            jovem.DataCasamento = (txtDataCasamento.SelectedDate != null) ? (DateTime)txtDataCasamento.SelectedDate : new Nullable<DateTime>();
            jovem.PossuiFilhos = (rbPossuiFilhos.SelectedIndex == 0) ? 'S' : 'N';
            jovem.DadosEspirituaisJovem.MesAnoAfastamento = txtMesAnoAfastamento.Text;
            jovem.DadosEspirituaisJovem.TempoAfastamento = txtTempoAfastamento.Text;
            jovem.DadosEspirituaisJovem.MesAnoBatismoAguas = txtDataBatismoAguas.Text;
            jovem.DadosEspirituaisJovem.MesAnoBatismoEspiritoSanto = txtDataBatismoEspiritoSanto.Text;

            testemunhoJovem.DescricaoVicio = txtNomeVicio.Text;
            

            facade.Save(jovem);
            facade.SaveValueObject<Testemunho>(testemunhoJovem);
            facade.SaveValueObject<DadosEspirituais>(jovem.DadosEspirituaisJovem);            

            string script = "function f(){CloseWindow(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }
    }
}
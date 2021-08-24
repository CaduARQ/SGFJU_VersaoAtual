using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class frmVisualizarIgrejas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                configuraControles(Request.QueryString["idRegiao"], Request.QueryString["nomeRegiao"]);
            }
        }
        private void configuraControles(string idRegiao, string nomeRegiao)
        {
            lblNomeRegiao.Text = nomeRegiao;
            preencheGridIgrejasJaCadastradas(idRegiao);
        }
        private void preencheGridIgrejasJaCadastradas(string idRegiao)
        {
            var facade = new FacadeEstadoImpl();
            var igrejasJaCadastradas = facade.obterIgrejasDaRegiao(new Regiao { Id = int.Parse(idRegiao) });
            Session.Add("IGREJAS_JA_CADASTRADAS", igrejasJaCadastradas);
            grdIgrejasRegiao.DataSource = igrejasJaCadastradas;
            grdIgrejasRegiao.DataBind();
        }

        protected void grdIgrejasRegiao_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e) {
            var igrejasJaCadastradas = (Session["IGREJAS_JA_CADASTRADAS"] as IList<Igreja>);
            grdIgrejasRegiao.DataSource = igrejasJaCadastradas;
        }

        protected void grdIgrejasRegiao_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            grdIgrejasRegiao.CurrentPageIndex = e.NewPageIndex;
            grdIgrejasRegiao.Rebind();
        }
    }
}
using HibernatingRhinos.Profiler.Appender.NHibernate;
using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class RegistraJovem2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CarregaGridTodosJovens();
        }

        private void CarregaGridTodosJovens()
        {
            NHibernateProfiler.Initialize();
            var facade = (new FacadeBaseImpl<Jovem>());
            IList<Jovem> todosJovens = null;
            if (Session["TodosJovens"] != null) {
                todosJovens = (Session["TodosJovens"] as IList<Jovem>);
                grdTodosJovens.DataSource = todosJovens;
                grdTodosJovens.DataBind();
            }
            else { 
                todosJovens = facade.ListAll();
                Session.Add("TodosJovens", todosJovens);
                grdTodosJovens.DataSource = todosJovens;
                grdTodosJovens.DataBind();
            }
        }
    }
}
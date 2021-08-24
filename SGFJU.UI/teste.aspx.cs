using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI
{
    public partial class teste : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                preecheControles();
        }

        private void preecheControles()
        {
            
        }

        protected void RadWizard1_FinishButtonClick(object sender, Telerik.Web.UI.WizardEventArgs e)
        {
            try
            {
                var facade = new FacadeBaseImpl<Jovem>();
                var novoJovem = new Jovem { };

                //facade.Save(novoJovem);
            }
            catch (DomainException excDominio)
            {
                throw;
            }
            catch (Exception exc)
            {
                throw;
            }
        }
    }
}
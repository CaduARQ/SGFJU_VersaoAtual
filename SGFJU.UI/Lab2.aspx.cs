using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI
{
    public partial class Lab2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            teste();
        }

        private void teste()
        {
            var estadoFacade = new FacadeEstadoImpl();
            var podeexcluir = estadoFacade.PodeExcluirBloco(new Bloco { Id = 2 });
            var podeexcluir2 = estadoFacade.PodeExcluirRegiao(new Regiao { Id = 2 });
        }
    }
}
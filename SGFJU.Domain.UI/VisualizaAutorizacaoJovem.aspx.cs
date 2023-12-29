using SGFJU.Domain.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.Domain.UI
{
    public partial class VisualizaAutorizacaoJovem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient objClient = new WebClient();
            var idJovem = Request.QueryString["idJovem"];
            var nomeArquivoDocumentoAutorizacaoJovem = Session["NomeArquivoDocumentoAutorizacaoJovem"].ToString();
            var dadosRelatorio = objClient.DownloadData(nomeArquivoDocumentoAutorizacaoJovem);

            Response.Clear();
            MemoryStream ms = new MemoryStream(dadosRelatorio);
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            ms.WriteTo(Response.OutputStream);
            Response.End();
        }
    }
}
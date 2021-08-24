using HibernatingRhinos.Profiler.Appender.NHibernate;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class ListaTodosJovens : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                CarregaGridTodosJovens();
        }

        private void CarregaGridTodosJovens() {
            //NHibernateProfiler.Initialize();
            var facade = (new FacadeJovemImpl());
            IList<Jovem> todosJovens = null;
            IList<TodosJovensDTO> todosDTO;
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            var caminhoArqquivoTodosJovens = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + "Todos.txt");

            if (this.EhADM) {

                if (System.IO.File.Exists(caminhoArqquivoTodosJovens)) {
                    todosDTO = facade.ListAllValueObjectsFromJson<TodosJovensDTO>(caminhoArqquivoTodosJovens).OrderBy(j => j.NomeJovem).ToList();
                    Session.Add("TodosJovens", todosDTO);
                    grdTodosJovens.DataSource = todosDTO;
                    grdTodosJovens.DataBind();
                }
                else {
                    Response.Redirect("../Views/RegistraJovem.aspx");
                }
                
            }
            else {
                if (System.IO.File.Exists(caminhoArqquivoTodosJovens))
                {
                    todosDTO = facade.ObterJovensPorEstado(this.UsuarioLogado.EstadoUsuario)
                                    .Select(j => new TodosJovensDTO { 
                                        IdEstado = UsuarioLogado.EstadoUsuario.Id,
                                        NomeEstado = UsuarioLogado.EstadoUsuario.NomeEstado,
                                        IdBlocoJovem = j.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.Id,
                                        NomeBlocoJovem = j.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.NomeBloco,
                                        IdRegiaoJovem = j.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                                        NomeRegiaoJovem = j.IgrejaAQualJovemPertence.RegiaoIgreja.NomeRegiao,
                                        IdIgreja = j.IgrejaAQualJovemPertence.Id,
                                        NomeIgrejaJovem = j.IgrejaAQualJovemPertence.NomeIgreja,
                                        DataNascimento = j.DataNascimento.ToString("dd/MM/yyyy"),
                                        IdJovem = j.Id,
                                        NomeJovem = j.Nome
                                    }).ToList();
                    //facade.ListAllValueObjectsFromJson<TodosJovensDTO>(caminhoArqquivoTodosJovens) as List<TodosJovensDTO>;
                    //var jovensSoEstado = todosDTO.Where(j => j.IdEstado == this.UsuarioLogado.EstadoUsuario.Id).OrderBy(n => n.NomeJovem).ToList();
                    Session.Add("TodosJovens", todosDTO);
                    grdTodosJovens.DataSource = todosDTO;
                    grdTodosJovens.DataBind();
                }
                else
                {
                    Response.Redirect("../Views/RegistraJovem.aspx");
                }
                //    todosJovens = facade.ObterJovensPorEstado(this.UsuarioLogado.EstadoUsuario).ToList();
            }
            
        }

        protected void grdTodosJovens_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e) {
            var todosJovens = (Session["TodosJovens"] as IList<TodosJovensDTO>);
            grdTodosJovens.DataSource = todosJovens;
        }
        protected void grdTodosJovens_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e) {
            grdTodosJovens.CurrentPageIndex = e.NewPageIndex;
            grdTodosJovens.Rebind();
        }
    }
}
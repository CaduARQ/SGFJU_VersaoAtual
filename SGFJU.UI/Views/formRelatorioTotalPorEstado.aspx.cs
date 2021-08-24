using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using SGFJU.ServicesLayer.DTO.Relatorios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class formRelatorioTotalPorEstado : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
                GeraRelatorio();

                if (this.EhADM)
                    lblNomeEstado.Text = "Todos";
                else
                    lblNomeEstado.Text = this.UsuarioLogado.EstadoUsuario.NomeEstado;
            }
        }

        private void GeraRelatorio() {
            var facade = (new FacadeJovemImpl());
            var facadeEstado = (new FacadeEstadoImpl());
            IList<TotalJovensPorBlocoDTO> relatorio = new List<TotalJovensPorBlocoDTO>();
            var estadosDoBrasil = new List<Estado>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            var caminhoArqquivoTodosJovens = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + "Todos.txt");

            if (this.EhADM) {
                if (System.IO.File.Exists(caminhoArqquivoTodosJovens)) {
                    estadosDoBrasil = (Session["TodosEstados"] as IList<Estado>).ToList();
                    
                    foreach (var estado in estadosDoBrasil) {
                        var blocosEstado = facadeEstado.obterBlocosDoEstado(estado);
                        var totalDeJovensEstado = 0;
                        foreach (var bloco in blocosEstado){
                            totalDeJovensEstado =
                                facade.ListAllValueObjectsFromJson<TodosJovensDTO>(caminhoArqquivoTodosJovens)
                                      .Where(jv => jv.IdBlocoJovem == bloco.Id &&
                                                   jv.IdEstado == estado.Id).Count();
                            relatorio.Add(new TotalJovensPorBlocoDTO { 
                                IdBloco = bloco.Id,
                                NomeBloco = bloco.NomeBloco,
                                IdEStado = estado.Id,
                                NomeEstado = estado.NomeEstado,
                                TotalJovensBloco = totalDeJovensEstado
                            });
                        }
                        Session.Add("RelatorioTotalPorEstado", relatorio);
                    }

                    grdTotalJovensPorBloco.DataSource = relatorio;
                    grdTotalJovensPorBloco.DataBind();
                }
             }
            else {
                if (System.IO.File.Exists(caminhoArqquivoTodosJovens)) {
                    var estadoLogado = this.UsuarioLogado.EstadoUsuario;
                    var blocosEstado = facadeEstado.obterBlocosDoEstado(this.UsuarioLogado.EstadoUsuario);
                    var totalDeJovensEstado = 0;
                    foreach (var bloco in blocosEstado) {
                        totalDeJovensEstado =
                            facade.ListAllValueObjectsFromJson<TodosJovensDTO>(caminhoArqquivoTodosJovens)
                                  .Where(jv => jv.IdBlocoJovem == bloco.Id &&
                                               jv.IdEstado == estadoLogado.Id).Count();
                        relatorio.Add(new TotalJovensPorBlocoDTO
                        {
                            IdBloco = bloco.Id,
                            NomeBloco = bloco.NomeBloco,
                            IdEStado = estadoLogado.Id,
                            NomeEstado = estadoLogado.NomeEstado,
                            TotalJovensBloco = totalDeJovensEstado
                        });
                    }
                    Session.Add("RelatorioTotalPorEstado", relatorio);
                }
            }
        }

        protected void grdTotalJovensPorBloco_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            grdTotalJovensPorBloco.DataSource = (Session["RelatorioTotalPorEstado"] as IList<TotalJovensPorBlocoDTO>);
        }

        protected void grdTotalJovensPorBloco_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            grdTotalJovensPorBloco.CurrentPageIndex = e.NewPageIndex;
        }
    }
}
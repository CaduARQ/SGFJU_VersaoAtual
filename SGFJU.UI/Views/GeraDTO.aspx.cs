using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.UI.Views
{
    public partial class GeraDTO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try {
                var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
                var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
                var caminhoPastaArquivosOndeSerializar = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + "Todos.txt");
                var facade = new FacadeJovemImpl();
                var todosJovens = facade.ListAllObjectsFromTypeAsDTO<Jovem, TodosJovensDTO>(J => new TodosJovensDTO
                {
                    IdEstado = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.Id,
                    NomeEstado = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.NomeEstado,
                    IdBlocoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.Id,
                    NomeBlocoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.NomeBloco,
                    IdRegiaoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                    NomeRegiaoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.NomeRegiao,
                    IdIgreja = J.IgrejaAQualJovemPertence.Id,
                    NomeIgrejaJovem = J.IgrejaAQualJovemPertence.NomeIgreja,
                    IdJovem = J.Id,
                    NomeJovem = J.Nome,
                    DataNascimento = J.DataNascimento.ToString("dd/MM/yyyy")
                }, caminhoPastaArquivosSerializados); ;

               (serializer as JSONSerializer).SerializeToJSON(todosJovens, caminhoPastaArquivosOndeSerializar);

                Response.Write("DTO Gerado com sucesso!!!");
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];
            
            var facade = new FacadeEstadoImpl();
            var estadosBrasil = facade.ListAll();

            foreach (var estado in estadosBrasil) {
                var nomeArquvioBloco = estado.SiglaEstado + "_Blocos.txt";
                var caminhoPastaArquivosOndeSerializar = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArquvioBloco);
                var blocosEstado = facade.obterBlocosDoEstado(estado).Select(b => new BlocoDTO { 
                    idBloco = b.Id,
                    NomeBloco = b.NomeBloco,
                    IdEstadoBloco = b.EstadoBloco.Id
                });

                (serializer as JSONSerializer).SerializeToJSON(blocosEstado, caminhoPastaArquivosOndeSerializar);
            }

            //var sw = new Stopwatch();
            //sw.Start();
            //var caminhoarquivo = @"C:\___0x048516_Sys\Todos.txt";
            //var todosJovensDTO = facade.ListAllValueObjectsFromJson<TodosJovensDTO>(caminhoarquivo);

            //sw.Stop();

            //Response.Write(sw.ElapsedTicks);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];

            var facade = new FacadeEstadoImpl();
            var estadosBrasil = facade.ListAll();

            foreach (var estado in estadosBrasil) {
                var nomeArqvuivoRegiao = estado.SiglaEstado + "_Regioes.txt";
                var caminhoPastaArquivosOndeSerializar = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArqvuivoRegiao);
                var regioesEstado = facade.obterTodasRegioesDoEstado(estado).Select(r => new RegiaoDTO
                {
                    idBloco = r.BlocoRegiao.Id,
                    IdRegiao = r.Id,
                    NomeRegiao = r.NomeRegiao
                });
                (serializer as JSONSerializer).SerializeToJSON(regioesEstado, caminhoPastaArquivosOndeSerializar);
            }
            Response.Write("DTO Regiões com sucesso !!!");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var caminhoPastaArquivosSerializados = ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"];

            var facade = new FacadeEstadoImpl();
            var estadosBrasil = facade.ListAll();

            foreach (var estado in estadosBrasil)
            {
                var nomeArqvuivoRegiao = estado.SiglaEstado + "_Igrejas.txt";
                var caminhoPastaArquivosOndeSerializar = Server.MapPath(caminhoPastaArquivosSerializados + "\\" + nomeArqvuivoRegiao);
                var igrejasEstado = facade.obterTodasIgrejasDoEstado(estado).Select(igj => new IgrejaDTO
                {
                    IdEstado = estado.Id,
                    //IdRegiao = igre
                    //IdIgreja = igj.Id,
                    NomeIgreja = igj.NomeIgreja
                });
                (serializer as JSONSerializer).SerializeToJSON(igrejasEstado, caminhoPastaArquivosOndeSerializar);
            }
            Response.Write("DTO Igrejas com sucesso !!!");
        }
    }
}
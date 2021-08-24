using SGFJU.Bussiness.Facade;
using SGFJU.Common.UnityContainer;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.UI.Helpers;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.Domain.UI
{
    public partial class TodosJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("::Iniciando geração do JSON ..........");

            GeraJSON();
        }

        //private void GeraJSON(string idestado, string siglaEstado)
        private void GeraJSON()
        {
            /*
            var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
            var facade = (new FacadeJovemImpl());
            var ret = facade.ListAll().Select(J => new TodosJovensDTO
            {
                IdEstado = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.Id,
                NomeEstado = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.EstadoBloco.NomeEstado,
                IdBlocoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.Id,
                NomeBlocoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.BlocoRegiao.NomeBloco,
                IdRegiaoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                NomeRegiaoJovem = J.IgrejaAQualJovemPertence.RegiaoIgreja.NomeRegiao,
                IdIgreja = J.IgrejaAQualJovemPertence.RegiaoIgreja.Id,
                NomeIgrejaJovem = J.IgrejaAQualJovemPertence.NomeIgreja,
                IdJovem = J.Id,
                NomeJovem = J.Nome,
                DataNascimento = J.DataNascimento.ToString("dd/MM/yyyy")
            });
            //var novoJovem = new TodosJovensDTO { 
            //    IdJovem = 1,
            //    NomeJovem = "Vitória",
            //    IdEstado = 1,
            //    NomeEstado = "SP",
            //    IdBlocoJovem = 1,
            //    NomeBlocoJovem = "Bloco vitória",
            //    IdRegiaoJovem = 1,
            //    NomeRegiaoJovem = "regiao vitória",
            //    IdIgreja = 1,
            //    NomeIgrejaJovem = "igreja perseverança",
            //    DataNascimento = ""
            //};
            var json = (serializer as JSONSerializer).SerializeToJSON(ret);
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();*/
            
            try {
                var serializer = (new UnityDIContainer()).GetServiceImplementationToType<Serializer>();
                var caminhoPastaArquivosSerializados = Server.MapPath(ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"]) + "\\AllStates.txt";
                //var caminhoPastaArquivosSerializados2 = Server.MapPath(ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"]) + "\\SP_AV.txt";
                var estadosBR = (new FacadeBaseImpl<Estado>()).ListAllValueObjectsFromJson<EstadoDTO>(caminhoPastaArquivosSerializados);
                //var obreirosAV = (new FacadeBaseImpl<Estado>()).ListAllValueObjectsFromJson<ObreiroDTO>(caminhoPastaArquivosSerializados2);

                var facadeAV = new FacadeArvoreVidaImpl();
                

                foreach (var estado in estadosBR) {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();

                    var nomeArquvioDestinoSerializar = Server.MapPath(ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"]) + "\\" + estado.SiglaEstado + "_AV.txt";
                    var nomeArquvioDestinoSerializarTE = Server.MapPath(ConfigurationManager.AppSettings["PathArquivosObjetosSerializados"]) + "\\" + estado.SiglaEstado + "_TempoGeracaoJSON.txt";
                    var obreirosComRamosEstado = facadeAV.ListaObreirosComRamosPorParametro(new PesquisaGeralDTO { IdEstado = estado.Id });
                    (serializer as JSONSerializer).SerializeToJSON(obreirosComRamosEstado, nomeArquvioDestinoSerializar);
                    Response.Write("Gerando JSON ..... Estado " + estado.NomeEstado);

                    stopWatch.Stop();
                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopWatch.Elapsed;

                    //// Format and display the TimeSpan value.
                    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                        ts.Hours, ts.Minutes, ts.Seconds,
                        ts.Milliseconds / 10);

                    (serializer as JSONSerializer)
                        .SerializeToJSON(new { 
                            TempoDecorridoSerializacao = elapsedTime,
                            Estado = estado.NomeEstado,
                            QuantidadeObreirosComRamos = obreirosComRamosEstado.Count
                        }, nomeArquvioDestinoSerializarTE);
                }
                

            }
            catch (Exception exc)
            {
                var mensagemTratada = ExceptionManager.FormatExceptionMessage(exc, "CAMADA_UI.Controller");
                LoggerHelper.WriteLogError(mensagemTratada);
                throw new Exception(exc.Message);
            }
        }
    }
}
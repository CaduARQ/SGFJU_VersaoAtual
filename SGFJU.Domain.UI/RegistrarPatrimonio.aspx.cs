using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.Model.ValueObjects;
using SGFJU.Interfaces;
using SGFJU.ServicesLayer.DTO;

namespace SGFJU.Domain.UI
{
    public partial class RegistrarPatrimonio : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtNomeItemPatrimonio"]))
            {
                SalvarPatrimonio();
            }
        }

        private void SalvarPatrimonio() {
            try {
                var facade = new PatrimonioFacadeImpl();
                var novoItemPatrimonio = new ItemPatrimonio
                {
                    NomeItemPatrimonio = Request.Form["txtNomeItemPatrimonio"],
                    DescricaoPatrimonio = Request.Form["txtDescricaoPatrimonio"],
                    Modelo = Request.Form["txtModelo"],
                    Marca = Request.Form["txtMarca"],
                    CategoriaItem = new CategoriaItemPatrimonio { Code = int.Parse(Request.Form["cboCategoriaPatrimonio"]) },
                    DataCompra = DateTime.Parse(Request.Form["txtDataCompra"]),
                    LocalCompra = Request.Form[""],
                    ValorUnitario = decimal.Parse(Request.Form["txtValor"]),
                    Quantidade = int.Parse(Request.Form["txtQuantidade"]),
                    NomeArquivoImagemItem1 = FileUploadPatrimonio1.FileName,
                    NomeArquivoImagemItem2 = FileUploadPatrimonio2.FileName,
                    NomeArquivoImagemItem3 = FileUploadPatrimonio3.FileName,
                    NomeArquivoImagemItem4 = FileUploadPatrimonio4.FileName,
                    NomeArquivoImagemItem5 = FileUploadPatrimonio5.FileName,
                };

                facade.Save(novoItemPatrimonio);

                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemConfirmacaoCadastro();", true);
            }
            catch (DomainException excDominio) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de domínio {0} : ", excDominio.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
            catch (FacadeException excBussiness) {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de negócios {0} : ", excBussiness.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
            catch (Exception generalException) {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
        }
    }
}
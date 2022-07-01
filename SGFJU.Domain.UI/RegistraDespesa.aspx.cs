using SGFJU.Bussiness.Facade;
using SGFJU.Bussiness.Facade.Exceptions;
using SGFJU.Domain.Model.DomainExceptions;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.Model.Infra.Logging.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGFJU.Domain.UI
{
    public partial class RegistraDespesa : SGFJUPaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["txtValor"]))
            {
                SalvarDespesa();
            }
        }

        private void SalvarDespesa()
        {
            try {
                var facade = new FacadeBaseImpl<Despesa>();
                var novaDespesa = new Despesa();
                novaDespesa.Valor = decimal.Parse(Request.Form["txtValor"]);
                novaDespesa.Descricao = Request.Form["txtDescricao"];
                novaDespesa.Data = DateTime.Parse(Request.Form["txtData"]);
                novaDespesa.NumeroDoCupom = Request.Form["txtNumeroCupom"];
                novaDespesa.NomeArquivoNota = FileUpload1.PostedFile.FileName;
                novaDespesa.EstadoDespesa = new Estado { Id = UsuarioLogado.EstadoUsuario.Id };

                var idEstado = Request.Form["cboEstado"];

                facade.Save(novaDespesa);

                (base.UserLogger as UserLoggerImpl).WriteUserAction(UsuarioLogado.Id, UsuarioLogado.EstadoUsuario.SiglaEstado, $"O usuário {UsuarioLogado.Login} cadastrou uma nova despesa de ID {novaDespesa.Id} ");

                uploadFotoNota(novaDespesa.Id, UsuarioLogado.EstadoUsuario.SiglaEstado);

                string script = "function f(){ mensagemConfirmacaoCadastro(); Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
                ClientScript.RegisterStartupScript(GetType(), "hwa", "mensagemConfirmacaoCadastro();", true);
            }
            catch (DomainException excDominio)
            {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de domínio {0} : ", excDominio.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
            catch (FacadeException excBussiness)
            {
                var mensagemErroExcecao = string.Format("Ocorreu o seguinte erro na camada de negócios {0} : ", excBussiness.Message);
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
            catch (Exception generalException)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(generalException, "CAMADA_APP");
                base.LoggerErrorApp.WriteLog(mensagemErroExcecao);
            }
        }
        private void uploadFotoNota(int idDespesa, string psiglaEstado)
        {
            try
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    string SaveLocation = Server.MapPath("FotosNotasDespesas") + "\\" + FileUpload1.PostedFile.FileName;
                    FileUpload1.PostedFile.SaveAs(SaveLocation);

                    if (File.Exists(SaveLocation))
                    {
                        var nomeArquivoFormatado = RetornaArquivofotoNotaFiscalFormatado(idDespesa, psiglaEstado, SaveLocation);

                        File.Move(SaveLocation, nomeArquivoFormatado);
                        File.Delete(SaveLocation);
                    }
                }
            }
            catch (Exception excUploadFoto)
            {
                var mensagemErroExcecao = ExceptionManager.FormatExceptionMessage(excUploadFoto, "CAMADA_APP");
                throw new Exception(mensagemErroExcecao);
            }
        }
        protected string RetornaArquivofotoNotaFiscalFormatado(int idDespesa, string pSiglaEstado, string filename)
        {
            string fDir = Path.GetDirectoryName(filename);
            string fName = Path.GetFileNameWithoutExtension(filename);
            string fExt = Path.GetExtension(filename);
            var data = DateTime.Now.ToString("yyyy-MM-dd");
            var hora = DateTime.Now.Hour.ToString();
            var minutos = DateTime.Now.Minute.ToString();
            var segundos = DateTime.Now.Second.ToString();
            var siglaEstado = pSiglaEstado;
            string suffix = $"{siglaEstado}_ID_DESPESA_{idDespesa}_{data}{hora}";
            string renamedFilePath = Path.Combine(fDir, String.Concat(suffix, fName, fExt));
            return renamedFilePath;
        }
    }
}
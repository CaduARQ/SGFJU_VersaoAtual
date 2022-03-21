using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SGFJU.Bussiness.Facade;
using SGFJU.Domain.Model.Entities;
using SGFJU.ServicesLayer.DTO;
using SGFJU.Domain.Model.Infra.ExceptionManager;
using SGFJU.Domain.UI.Helpers;

namespace SGFJU.Domain.UI.Controllers
{
    public class GerenciaPatrimonioController : ApiController
    {

        [HttpPost]
        [Route("api/GerenciaPatrimonio/RegistrarItemDePatrimonio/")]
        public RespostaRequisicaoDTO RegistrarItemDePatrimonio([FromBody] ItemPatrimonioDTO itemPatrimonio ) {
            try {
                var facade = new FacadeBaseImpl<ItemPatrimonio>();
                facade.Save(new ItemPatrimonio {
                    NomeItemPatrimonio = itemPatrimonio.NomeItemPatrimonio,
                    DescricaoPatrimonio = itemPatrimonio.DescricaoPatrimonio,
                    EstadoItemPatrimonio = new Estado { Id = SessionHelper.RetornaEstadoUsuarioLogado().Id },
                    Modelo = itemPatrimonio.Modelo,
                    Marca = itemPatrimonio.Marca,
                    LocalCompra = itemPatrimonio.LocalCompra,
                    DataCompra = DateTime.Parse( itemPatrimonio.DataCompra ),
                    ValorUnitario = decimal.Parse( itemPatrimonio.ValorUnitario ),
                    Quantidade = itemPatrimonio.Quantidade,
                    CategoriaItem = new Model.ValueObjects.CategoriaItemPatrimonio { Code =  itemPatrimonio.CodigoCategoriaItem },
                    NomeArquivoCartaDoacao = itemPatrimonio.NomeArquivoCartaDoacao,
                    NomeArquivoPDFNotaFiscal = itemPatrimonio.NomeArquivoPDFNotaFiscal,
                    NomeArquivoImagemItem1 = itemPatrimonio.NomeArquivoImagemItem1,
                    NomeArquivoImagemItem2 = itemPatrimonio.NomeArquivoImagemItem2,
                    NomeArquivoImagemItem3 = itemPatrimonio.NomeArquivoImagemItem3,
                    NomeArquivoImagemItem4 = itemPatrimonio.NomeArquivoImagemItem4,
                    NomeArquivoImagemItem5 = itemPatrimonio.NomeArquivoImagemItem5
                });

                return new RespostaRequisicaoDTO { RequisicaoBemSucedida = true, MensagemRespostaRequisicao = "Patrimônio registrado com sucesso!" };
            }
            catch (Exception exc) {
                var mensagemFormatada = ExceptionManager.FormatExceptionMessage(exc);
                throw new Exception(mensagemFormatada);
            }
        }
    }
}

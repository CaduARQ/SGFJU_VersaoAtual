using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.ExceptionManager
{
    public class ExceptionManager {
        public static string FormatExceptionMessage(Exception exception, string origemExcecao = "") {
            var stack = exception.StackTrace;
            var sourceExc = exception.Source;
            var innerExcStr = (exception.InnerException!=null)?exception.InnerException.Message:"";
            var innerExcMsg = exception.Message;
            var origem = origemExcecao;
            var mensagemErroformatada = $"Erro ocorrido {origem} \n\n " +
                                        $" StackTrace: {stack}: \n\n" +
                                        $" Source: {sourceExc}  \n\n"                    +
                                        $" Inner Exception: {innerExcStr} \n\n "         +
                                        $" Exception Message: {innerExcMsg} \n\n " +
                                        "--------------------------------------";
            return mensagemErroformatada;
        }
        public static string FormatExceptionMessage(Exception exception)
        {
            var stack = exception.StackTrace;
            var sourceExc = exception.Source;
            var innerExcStr = exception.InnerException;
            var innerExcMsg = exception.Message;
            var mensagemErroformatada = $"Erro  \n\n " +
                                        $" StackTrace: {stack}: \n\n" +
                                        $" Source: {sourceExc}  \n\n" +
                                        //$" Inner Exception: {innerExcStr} \n\n " +
                                        $" Inner Exception Message: {innerExcMsg} \n\n " +
                                        "--------------------------------------";
            return mensagemErroformatada;
        }
        public static string FormatExceptionMessage(Exception exception, string nomeMetodo, string nomeCamada)
        {
            var stack = exception.StackTrace;
            var sourceExc = exception.Source;
            var innerExcStr = exception.InnerException;
            var innerExcMsg = exception.Message;
            var mensagemErroformatada = $"Erro  \n\n " +
                                        $" StackTrace: {stack}: \n\n" +
                                        $" Source: {sourceExc}  \n\n" +
                                        $" Inner Exception Message: {innerExcMsg} \n\n " +

                                        $" Método: {nomeMetodo} \n\n " +
                                        $" Camada: {nomeCamada} \n\n " +
                                        "--------------------------------------";
            return mensagemErroformatada;
        }
    }
}

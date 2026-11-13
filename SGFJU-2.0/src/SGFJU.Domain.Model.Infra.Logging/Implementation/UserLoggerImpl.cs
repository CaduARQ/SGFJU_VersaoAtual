using NLog;
using SGFJU.Domain.Model.Entities;
using SGFJU.Domain.Model.Infra.Logging.Abstractions;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.ServicesLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGFJU.Domain.Model.Infra.Logging.Implementation
{
    public class UserLoggerImpl : LoggerImpl, UserLogger
    {
        private string __pathUserActionsLog;
        public UserLoggerImpl()
            : base(){}
        public UserLoggerImpl(string pathUserActionsLogFile)
        {
            this.__pathUserActionsLog = pathUserActionsLogFile;
        }
        public void WriteUserAction(string message, string action, Usuario user)
        {
            var logger = LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();

            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = this.__pathUserActionsLog };
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = this.__pathUserActionsLog, Layout = "${message}|" };

            config.AddRule(LogLevel.Info, LogLevel.Info, logfile);

            NLog.LogManager.Configuration = config;

            var messageLog = "O usuário {0} - executour a seguinte ação: {1}, com a seguinte descrição: {2} - a data {3}";

            logger.Info(string.Format(messageLog, user.NomeUsuario, action, message, DateTime.Now));
        }

        public void WriteUserAction(LogUsuarioDTO dtoActionUser) {
            var logger = LogManager.GetCurrentClassLogger();

            var config = new NLog.Config.LoggingConfiguration();

            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = this.__pathUserActionsLog };
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = this.__pathUserActionsLog, Layout = "${message}|" };

            config.AddRule(LogLevel.Info, LogLevel.Info, logfile);

            NLog.LogManager.Configuration = config;

            var serializer = (new JSONSerializer());

            var dtoAcaoUsuarioSerializado = serializer.SerializeToJSON(dtoActionUser);

            logger.Info(dtoAcaoUsuarioSerializado);
        }

        public void WriteUserAction(int pIdUsuario, string pSiglaEstado, string pDescricaoAcaoUsuario)
        {
            var logger = LogManager.GetCurrentClassLogger();

            var logUsuarioDTO = new LogUsuarioDTO{
                IdLogUsuario = pIdUsuario+DateTime.Now.Millisecond,
                IdUsuario = pIdUsuario,
                SiglaEstadoUsuario = pSiglaEstado,
                DataAcaoUsuario = DateTime.Now.ToString("dd/MM/yyyy"),
                DescricaoAcaoUsuario = pDescricaoAcaoUsuario,
                HorarioAcaoUsuario = $" {DateTime.Now.Hour} horas e {DateTime.Now.Minute} minutos"
            };

            var config = new NLog.Config.LoggingConfiguration();

            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = this.__pathUserActionsLog };
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = this.__pathUserActionsLog, Layout = "${message}|" };

            config.AddRule(LogLevel.Info, LogLevel.Info, logfile);

            NLog.LogManager.Configuration = config;

            var serializer = (new JSONSerializer());

            var dtoAcaoUsuarioSerializado = serializer.SerializeToJSON(logUsuarioDTO);

            logger.Info(dtoAcaoUsuarioSerializado);
        }
    }
}

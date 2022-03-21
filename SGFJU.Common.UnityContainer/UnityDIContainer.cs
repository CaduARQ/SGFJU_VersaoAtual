using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using SGFJU.Interfaces;
using SGFJU.Domain.Model.Repositories;
using SGFJU.Domain.Model.Infra.DataAccess.MySql.Implementation;
using SGFJU.Domain.Model.Infra.Serialization;
using SGFJU.Domain.Model.Infra.Logging.Abstractions;
using SGFJU.Domain.Model.Infra.Logging.Implementation;

namespace SGFJU.Common.UnityContainer
{
    public class UnityDIContainer : DIContainer
    {
        private IUnityContainer __unityContainer;

        public UnityDIContainer()
        {
            __unityContainer = new Unity.UnityContainer();
            __unityContainer.RegisterType(typeof(Repository<>), typeof(RepositoryImpl<>));
            __unityContainer.RegisterType(typeof(JovemRepository), typeof(JovemRepositoryImpl));
            __unityContainer.RegisterType(typeof(EstadoRepository), typeof(EstadoRepositoryImpl));
            __unityContainer.RegisterType(typeof(UsuarioRepository), typeof(UsuarioRepositoryImpl));
            __unityContainer.RegisterType(typeof(DashboardRelatorioRepository), typeof(DashboardRelatorioRepositoryImpl));
            __unityContainer.RegisterType(typeof(AltarJovemRepository), typeof(AltarJovemRepositoryImpl));
            __unityContainer.RegisterType(typeof(CoordenadorRepository), typeof(CoordenadorRepositoryImpl));
            __unityContainer.RegisterType(typeof(ArvoreVidaRepository), typeof(ArvoreVidaRepositoryImpl));
            __unityContainer.RegisterType(typeof(AVDashboardRepository), typeof(AVDashboardRepositoryImpl));
            __unityContainer.RegisterType(typeof(BuscaAvancadaTestemunhoRepository), typeof(BuscaAvancadaTestemunhoRepositoryImpl));
            __unityContainer.RegisterType(typeof(RelatorioReuniaoFJUIgrejaRepository), typeof(RelatorioReuniaoFJUIgrejaRepositoryImpl));
            __unityContainer.RegisterType(typeof(Serializer), typeof(JSONSerializer));

            __unityContainer.RegisterType(typeof(ErrorLogger), typeof(ErrorLoggerImpl));
            __unityContainer.RegisterType(typeof(UserLogger), typeof(UserLoggerImpl));
        }

        public void RegisterAbstraction(Type abstraction, Type implementation)
        {
            this.__unityContainer.RegisterType(abstraction, implementation);
        }

        public void RegisterAbstractionForAInstance(Type abstraction, object instanceAbstractionImplementation)
        {
            this.__unityContainer.RegisterInstance(abstraction);
        }

        public object GetServiceImplementation(Type abstraction)
        {
            return this.__unityContainer.Resolve(abstraction);
        }

        public TToType GetServiceImplementationToType<TToType>() where TToType : class
        {
            return this.__unityContainer.Resolve(typeof(TToType)) as TToType;
        }
    }
}

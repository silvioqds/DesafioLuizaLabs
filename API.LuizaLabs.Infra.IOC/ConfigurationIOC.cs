using System;
using API.LuizaLabs.Application.Interface;
using API.LuizaLabs.Application.Service;
using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Core.Service;
using API.LuizaLabs.Infra.Repository.Repository;
using API.LuizaLabs.Services;
using Autofac;

namespace API.LuizaLabs.Infra.IOC
{
    public class ConfigurationIOC
    {

        public static void Loader(ContainerBuilder builder)
        {

            #region Application Services

            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ApplicationServiceProduct>().As<IApplicationServiceProduct>();
            builder.RegisterType<ApplicationServiceFavorite>().As<IApplicationServiceFavorite>();
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();

            #endregion

            #region Services

            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<ServiceProduct>().As<IServiceProduct>();
            builder.RegisterType<ServiceFavorite>().As<IServiceFavorite>();
            builder.RegisterType<ServiceUser>().As<IServiceUser>();

            #endregion

            #region Repositorys

            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
            builder.RegisterType<RepositoryProduct>().As<IRepositoryProduct>();
            builder.RegisterType<RepositoryFavorite>().As<IRepositoryFavorite>();
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();

            #endregion


        }

    }
}

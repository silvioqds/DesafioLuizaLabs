using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Core.Service;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Services
{

    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        public readonly IRepositoryCliente _repositoryCliente;

        public ServiceCliente(IRepositoryCliente repository)
            : base(repository)
        {
            _repositoryCliente = repository;
        }

        public Cliente GetByEmail(string email)
        {
            return _repositoryCliente.GetByEmail(email);
        }
    }

}

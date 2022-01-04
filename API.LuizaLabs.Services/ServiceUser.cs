using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Core.Service;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Services
{
    public class ServiceUser : ServiceBase<User>, IServiceUser
    {

        private readonly IRepositoryUser _repository;
        public ServiceUser(IRepositoryUser repository)
            :base(repository)
        {
            this._repository = repository;
        }

        public User Authenticate(string username, string pass)
        {
            return _repository.Authenticate(username, pass);
        }
    }
}

using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Core.Service;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Services
{
    public class ServiceFavorite : ServiceBase<Favorite>, IServiceFavorite
    {

        private readonly IRepositoryFavorite _repositoryFavorite;

        public ServiceFavorite(IRepositoryFavorite repositoryFavorite)
            : base(repositoryFavorite)
        {
            this._repositoryFavorite = repositoryFavorite;
        }

        public IEnumerable<Product> GetByCliente(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByProduto(int ID)
        {
            throw new NotImplementedException();
        }
    }
}

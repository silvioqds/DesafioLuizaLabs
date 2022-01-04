using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Core.Service;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Services
{
    public class ServiceProduct : ServiceBase<Product>, IServiceProduct
    {

        public readonly IRepositoryProduct _repositoryProduct;


        public ServiceProduct(IRepositoryProduct repositoryProduct)
            :base(repositoryProduct)
        {
            this._repositoryProduct = repositoryProduct;
        }

        public IEnumerable<Product> GetAll(int? page)
        {
            page ??= 1;
            if (page <= 0) page = 1;

            return _repositoryProduct.GetAll(page.GetValueOrDefault());
        }
    }
}

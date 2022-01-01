using API.LuizaLabs.Data;
using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Infra.Repository.Repository
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {

        private readonly SQLContext _context;

        public RepositoryProduct(SQLContext context)
            : base(context)
        {
            this._context = context;
        }

    }
}

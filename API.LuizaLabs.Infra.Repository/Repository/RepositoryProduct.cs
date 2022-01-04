using API.LuizaLabs.Data;
using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public IEnumerable<Product> GetAll(int page)
        {

            return _context.Set<Product>().AsNoTracking()
             .OrderBy(c => c.Id)
             .Skip(10 * (page - 1)).Take(10);

        }

    }
}

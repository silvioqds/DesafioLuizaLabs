using API.LuizaLabs.Data;
using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.LuizaLabs.Infra.Repository.Repository
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private readonly SQLContext _context;

        public RepositoryCliente(SQLContext context)
            : base(context)
        {
            this._context = context;
        }

        public Cliente GetByEmail(string email)
        {
            return _context.Set<Cliente>().Where(x => x.Email == email).FirstOrDefault();
        }
    }
}

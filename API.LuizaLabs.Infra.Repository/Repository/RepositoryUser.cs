using API.LuizaLabs.Data;
using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.LuizaLabs.Infra.Repository.Repository
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {

        private readonly SQLContext _context;

        public RepositoryUser(SQLContext context)
            :base(context)
        {
            this._context = context;
        }

        public User Authenticate(string username, string pass)
        {
            return _context.Set<User>().SingleOrDefault(x => x.Username == username && x.Password == pass);
        }
    }
}

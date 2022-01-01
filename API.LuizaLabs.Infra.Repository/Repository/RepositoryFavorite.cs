using API.LuizaLabs.Data;
using API.LuizaLabs.Domain.Core.Repository;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.LuizaLabs.Infra.Repository.Repository
{
    public class RepositoryFavorite : RepositoryBase<Favorite>, IRepositoryFavorite
    {

        private readonly SQLContext _context;

        public RepositoryFavorite(SQLContext context)
            : base(context)
        {
            this._context = context;
        }

        public IEnumerable<Favorite> GetByCliente(int ID)
        {
            return _context.Set<Favorite>().Where(x => x.ID_CLIENTE == ID).ToList();
        }

        public IEnumerable<Favorite> GetByProduto(int ID)
        {
            return _context.Set<Favorite>().Where(x => x.ID_PRODUTO == ID).ToList();
        }
    }
}

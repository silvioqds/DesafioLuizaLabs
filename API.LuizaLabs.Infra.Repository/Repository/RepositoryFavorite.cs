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
            return _context.Set<Favorite>().Where(x => x.ClienteId == ID).ToList();
        }

        public IEnumerable<Favorite> GetByProduto(int ID)
        {
            return _context.Set<Favorite>().Where(x => x.ProductId == ID).ToList();
        }

        public Favorite GetByProdutoAndCliente(int ID_CLIENTE, int ID_PRODUTO)
        {
            return _context.Set<Favorite>().Where(x => x.ClienteId == ID_CLIENTE && x.ProductId == ID_PRODUTO).FirstOrDefault();
        }
    }
}

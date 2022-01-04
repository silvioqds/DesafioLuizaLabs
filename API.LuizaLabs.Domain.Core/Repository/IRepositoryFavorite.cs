using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Domain.Core.Repository
{
    public interface IRepositoryFavorite : IRepositoryBase<Favorite>
    {
        IEnumerable<Favorite> GetByCliente(int ID);

        IEnumerable<Favorite> GetByProduto(int ID);

        Favorite GetByProdutoAndCliente(int ProdutoID, int ClienteID);
    }
}

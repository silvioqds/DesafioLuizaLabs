using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;

namespace API.LuizaLabs.Domain.Core.Service
{
    public interface IServiceFavorite : IServiceBase<Favorite>, IDisposable
    {
        IEnumerable<Favorite> GetByCliente(int ID);

        IEnumerable<Favorite> GetByProduto(int ID);

        Favorite GetByProdutoAndCliente(int ClienteID, int ProdutoID);
    }
}

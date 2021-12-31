using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Domain.Core.Service
{
    public interface IServiceFavorite : IServiceBase<Favorite>, IDisposable
    {
        IEnumerable<Product> GetByCliente(int ID);

        IEnumerable<Product> GetByProduto(int ID);
    }
}

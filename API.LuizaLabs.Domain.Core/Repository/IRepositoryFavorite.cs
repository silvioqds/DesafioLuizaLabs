using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Domain.Core.Repository
{
    public interface IRepositoryFavorite : IRepositoryBase<Favorite>
    {
        IEnumerable<Product> GetByCliente(int ID);

        IEnumerable<Product> GetByProduto(int ID);
    }
}

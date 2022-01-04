using API.LuizaLabs.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace API.LuizaLabs.Domain.Core.Repository
{
    public interface IRepositoryProduct : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAll(int page);
    }
}

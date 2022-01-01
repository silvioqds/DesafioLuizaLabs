using API.LuizaLabs.Domain.Models;

namespace API.LuizaLabs.Domain.Core.Repository
{
    public interface IRepositoryCliente : IRepositoryBase<Cliente>
    {
        Cliente GetByEmail(string email);
    }
}

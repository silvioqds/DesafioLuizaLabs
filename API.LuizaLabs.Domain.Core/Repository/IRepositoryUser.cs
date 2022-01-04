using API.LuizaLabs.Domain.Models;

namespace API.LuizaLabs.Domain.Core.Repository
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        User Authenticate(string username, string pass);
    }
}

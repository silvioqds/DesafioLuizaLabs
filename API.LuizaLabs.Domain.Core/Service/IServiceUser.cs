using API.LuizaLabs.Domain.Models;

namespace API.LuizaLabs.Domain.Core.Service
{
    public interface IServiceUser : IServiceBase<User>
    {
        User Authenticate(string username, string pass);
    }
}

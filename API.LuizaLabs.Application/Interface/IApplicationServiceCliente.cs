using API.LuizaLabs.Application.DTO.DTO;
using System.Collections.Generic;

namespace API.LuizaLabs.Application.Interface
{
    public interface IApplicationServiceCliente
    {
        
        ClienteDTO Get(int ID);

        IEnumerable<ClienteDTO> GetAll();

        void Add(ClienteDTO obj);

        void Update(ClienteDTO obj);

        void Remove(ClienteDTO obj);

        ClienteDTO GetByEmail(string email);

        void Dispose();

    }
}

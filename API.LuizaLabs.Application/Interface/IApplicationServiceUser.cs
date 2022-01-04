using API.LuizaLabs.Application.DTO.DTO;
using API.LuizaLabs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Application.Interface
{
    public interface IApplicationServiceUser
    {
        IEnumerable<UserDTO> GetAll();

        void Add(UserDTO obj);

        void Update(UserDTO obj);

        void Remove(UserDTO obj);

        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}

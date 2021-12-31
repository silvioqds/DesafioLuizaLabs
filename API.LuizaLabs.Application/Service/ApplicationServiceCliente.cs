using API.LuizaLabs.Application.DTO.DTO;
using API.LuizaLabs.Application.Interface;
using API.LuizaLabs.Domain.Core.Service;
using API.LuizaLabs.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Application.Service
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente _serviceCliente;
        private readonly IMapper _mapper;

        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapper mapper)
        {
            this._serviceCliente = serviceCliente;
            this._mapper = mapper;
        }

        public ClienteDTO Get(int ID)
        {
            throw new NotImplementedException();
        }

        public ClienteDTO GetByEmail(string email)
        {
            return _mapper.Map<ClienteDTO>(_serviceCliente.GetByEmail(email));
        }

        public IEnumerable<ClienteDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(ClienteDTO obj)
        {
            if (!(GetByEmail(obj.Email) is null))
            {

            }

            _serviceCliente.Save(_mapper.Map<Cliente>(obj));
        }

        public void Update(ClienteDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(ClienteDTO obj)
        {
            throw new NotImplementedException();
        }



        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}

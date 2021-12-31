using API.LuizaLabs.Application.DTO.DTO;
using API.LuizaLabs.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Application.Service
{
    public class ApplicationServiceFavorite : IApplicationServiceFavorite
    {
        public void Add(FavoriteDTO obj)
        {
            throw new NotImplementedException();
        }
      
        public IEnumerable<FavoriteDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetByCliente(int ID_CLIENTE)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetByProduto(int ID_PRODUTO)
        {
            throw new NotImplementedException();
        }

        public void Remove(FavoriteDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Update(FavoriteDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}

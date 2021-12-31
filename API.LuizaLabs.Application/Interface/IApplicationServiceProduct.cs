using API.LuizaLabs.Application.DTO.DTO;
using System.Collections.Generic;

namespace API.LuizaLabs.Application.Interface
{
    public interface IApplicationServiceProduct
    {

        ProductDTO Get(int ID);

        IEnumerable<ProductDTO> GetAll();

        void Add(ProductDTO obj);

        void Update(ProductDTO obj);

        void Remove(ProductDTO obj);

        void Dispose();


    }
}

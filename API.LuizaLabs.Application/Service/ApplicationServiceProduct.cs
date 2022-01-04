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
    public class ApplicationServiceProduct : IApplicationServiceProduct
    {

        private readonly IServiceProduct _serviceProduct;
        private readonly IMapper _mapper;


        public ApplicationServiceProduct(IServiceProduct serviceProduct, IMapper mapper)
        {
            this._serviceProduct = serviceProduct;
            this._mapper = mapper;
        }

        public ProductDTO Get(int ID)
        {
            return _mapper.Map<ProductDTO>(_serviceProduct.Get(ID));
        }

        public IEnumerable<ProductDTO> GetAll(int? page)
        {
            return _mapper.Map<List<ProductDTO>>(_serviceProduct.GetAll());
        }

        public void Add(ProductDTO obj)
        {            
            _serviceProduct.Save(_mapper.Map<Product>(obj));
        }

        public void Update(ProductDTO obj)
        {            
            _serviceProduct.Save(_mapper.Map<Product>(obj));
        }

        public void Remove(ProductDTO obj)
        {            
            _serviceProduct.Remove(_mapper.Map<Product>(obj));
        }

        public void Dispose()
        {
            _serviceProduct.Dispose();
        }

    }
}

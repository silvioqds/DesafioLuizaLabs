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
    public class ApplicationServiceFavorite : IApplicationServiceFavorite
    {

        private readonly IServiceFavorite _serviceFavorite;
        private readonly IServiceProduct _serviceProduct;
        private readonly IMapper _mapper;

        public ApplicationServiceFavorite(IServiceFavorite serviceFavorite, IServiceProduct serviceProduct, IMapper mapper)
        {
            this._serviceFavorite = serviceFavorite;
            this._serviceProduct = serviceProduct;
            this._mapper = mapper;
        }

        public void Add(FavoriteDTO obj)
        {
            Product product = _serviceProduct.Get(obj.ProductId);

            if (product is null)
                throw new Exception("Produto não cadastrado");

            Favorite favorite = GetByProdutoAndCliente(obj.ClienteId, obj.ProductId);

            if (!(favorite is null))
                throw new Exception("Não é possível adicionar o mesmo produto na lista de favoritos");

            _serviceFavorite.Save(_mapper.Map<Favorite>(obj));
        }

        public IEnumerable<FavoriteDTO> GetAll()
        {
            return _mapper.Map<List<FavoriteDTO>>(_serviceFavorite.GetAll());
        }

        public IEnumerable<ProductDTO> GetByCliente(int ID_CLIENTE)
        {
            return _mapper.Map<List<ProductDTO>>(_serviceFavorite.GetByCliente(ID_CLIENTE));
        }

        public IEnumerable<ProductDTO> GetByProduto(int ID_PRODUTO)
        {
            return _mapper.Map<List<ProductDTO>>(_serviceFavorite.GetByCliente(ID_PRODUTO));
        }

        public void Remove(FavoriteDTO obj)
        {
            _serviceFavorite.Remove(_mapper.Map<Favorite>(obj));
        }

        public void Update(FavoriteDTO obj)
        {
            _serviceFavorite.Update(_mapper.Map<Favorite>(obj));
        }

        private IEnumerable<ProductDTO> GetByCliente(int ID_CLIENTE, int ID_PRODUTO)
        {
            return _mapper.Map<List<ProductDTO>>(_serviceFavorite.GetByCliente(ID_CLIENTE));
        }


        public Favorite GetByProdutoAndCliente(int ClienteID, int ProdutoID)
        {
            return _serviceFavorite.GetByProdutoAndCliente(ClienteID, ProdutoID);
        }

        public void Dispose()
        {
            _serviceFavorite.Dispose();
        }


    }
}

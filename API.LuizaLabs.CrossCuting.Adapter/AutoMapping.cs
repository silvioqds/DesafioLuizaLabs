using API.LuizaLabs.Application.DTO.DTO;
using API.LuizaLabs.Domain.Models;
using AutoMapper;
using System;

namespace API.LuizaLabs.CrossCuting.Adapter
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Favorite, FavoriteDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}

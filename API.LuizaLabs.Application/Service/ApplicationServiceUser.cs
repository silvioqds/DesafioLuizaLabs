using API.LuizaLabs.Application.DTO.DTO;
using API.LuizaLabs.Application.Helpers;
using API.LuizaLabs.Application.Interface;
using API.LuizaLabs.Domain.Core.Service;
using API.LuizaLabs.Domain.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.LuizaLabs.Application.Service
{
    public class ApplicationServiceUser : IApplicationServiceUser
    {

        private readonly IServiceUser _service;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        
        public ApplicationServiceUser(IServiceUser service, IOptions<AppSettings> appSettings, IMapper mapper)
        {            
            this._service = service;
            this._appSettings = appSettings.Value;
            this._mapper = mapper;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _mapper.Map<List<UserDTO>>(_service.GetAll());
        }

        public void Add(UserDTO obj)
        {
            _service.Save(_mapper.Map<User>(obj));
        }
              
        public void Remove(UserDTO obj)
        {
            _service.Remove(_mapper.Map<User>(obj));
        }

        public void Update(UserDTO obj)
        {
            _service.Update(_mapper.Map<User>(obj));
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            User user = _service.Authenticate(model.Username, model.Password);

            if (user is null)
                return null;

            var token = GenerateJWToken(user);

            return new AuthenticateResponse(user, token);
        }

        /// <summary>
        /// Recebe o Usuário como parâmetro e gera o token para o mesmo dentro da aplicação
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateJWToken(User user)
        {
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1), // EXPIRA DENTRO DE 1 DIA
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

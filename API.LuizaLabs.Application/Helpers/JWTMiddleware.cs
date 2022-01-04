using API.LuizaLabs.Domain.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.LuizaLabs.Application.Helpers
{
    public class JWTMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JWTMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            this._next = next;
            this._appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IServiceUser service)
        {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, service, token);

            await _next(context);
        }

        public void AttachUserToContext(HttpContext context, IServiceUser service, string token)
        {
            try
            {
                JwtSecurityTokenHandler jwtSecurityToken = new JwtSecurityTokenHandler();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                jwtSecurityToken.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userID = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                context.Items["User"] = service.Get(userID);
            }
            catch
            {

            }

        }



    }
}

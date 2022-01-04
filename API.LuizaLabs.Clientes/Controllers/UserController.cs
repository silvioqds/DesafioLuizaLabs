using API.LuizaLabs.Application.DTO.DTO;
using API.LuizaLabs.Application.Helpers;
using API.LuizaLabs.Application.Interface;
using API.LuizaLabs.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.LuizaLabs.Clientes.Controllers
{

    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IApplicationServiceUser _serviceUser;

        public UserController(IApplicationServiceUser serviceUser)
        {
            this._serviceUser = serviceUser;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            AuthenticateResponse response = _serviceUser.Authenticate(request);

            if (response is null)
                return BadRequest(new { message = "Username or passaword incorreto(os)!" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("user")]
        public IActionResult GetAll()
        {
            return Ok(_serviceUser.GetAll());
        }

        [Authorize]
        [HttpPost("user")]
        public IActionResult Post([FromBody] UserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                                           .SelectMany(x => x.Errors)
                                           .Select(c => c.ErrorMessage));
                    return BadRequest(message);
                }

                _serviceUser.Add(user);
                return Ok(new { message = "Usuario adicionado com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "O servidor não pode atender a solicitação, contate o administrador do serviço" });
            }
        }




    }
}

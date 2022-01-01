using API.LuizaLabs.Application.DTO.DTO;
using API.LuizaLabs.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.LuizaLabs.Clientes.Controllers
{

    [Route("api")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IApplicationServiceCliente _applicationServiceCliente;

        public ClienteController(IApplicationServiceCliente application)
        {
            this._applicationServiceCliente = application;
        }

        [HttpGet("cliente")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceCliente.GetAll());
        }

        [HttpGet("cliente/{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceCliente.Get(id));
        }

        [HttpPost("cliente")]
        public ActionResult Post([FromBody] ClienteDTO cliente)
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

                _applicationServiceCliente.Add(cliente);
                return Ok("Cliente cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("cliente")]
        public ActionResult Put([FromBody] ClienteDTO cliente)
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

                _applicationServiceCliente.Update(cliente);
                return Ok("Cliente atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("cliente")]
        public ActionResult Delete([FromBody] ClienteDTO cliente)
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

                _applicationServiceCliente.Remove(cliente);
                return Ok("Cliente removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }




    }
}

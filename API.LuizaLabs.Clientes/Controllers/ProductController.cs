using API.LuizaLabs.Application.DTO.DTO;
using API.LuizaLabs.Application.Helpers;
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
    public class ProductController : ControllerBase
    {
        private readonly IApplicationServiceProduct _serviceProduct;


        public ProductController(IApplicationServiceProduct serviceProduct)
        {
            this._serviceProduct = serviceProduct;
        }


        [Authorize]
        [HttpGet("product/{page?}")]
        public ActionResult<IEnumerable<string>> Get(int? page)
        {
            return Ok(_serviceProduct.GetAll(page));
        }

        [Authorize]
        [HttpGet("product/{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_serviceProduct.Get(id));
        }

        [Authorize]
        [HttpPost("product")]
        public ActionResult Post([FromBody] ProductDTO product)
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

                _serviceProduct.Add(product);
                return Ok(new { message = "Produto cadastrado com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("product")]
        public ActionResult Put([FromBody] ProductDTO product)
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

                _serviceProduct.Update(product);
                return Ok(new { message = "Produto atualizado com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete("product")]
        public ActionResult Delete([FromBody] ProductDTO product)
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

                _serviceProduct.Remove(product);
                return Ok(new { message = "Produto removido com sucesso!" });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}

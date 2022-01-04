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
    public class FavoriteController : ControllerBase
    {

        private readonly IApplicationServiceFavorite _serviceFavorite;

        public FavoriteController(IApplicationServiceFavorite serviceFavorite)
        {
            this._serviceFavorite = serviceFavorite;
        }


        [Authorize]
        [HttpGet("favorite")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_serviceFavorite.GetAll());
        }

        [Authorize]
        [HttpGet("favorite/favorite/{id}")]
        public ActionResult<string> GetByCliente(int id)
        {
            return Ok(_serviceFavorite.GetByCliente(id));
        }

        [Authorize]
        [HttpGet("favorite/produto/{id}")]
        public ActionResult<string> GetByProduto(int id)
        {
            return Ok(_serviceFavorite.GetByProduto(id));
        }


        [Authorize]
        [HttpPost("favorite")]
        public ActionResult Post([FromBody] FavoriteDTO favorite)
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

                _serviceFavorite.Add(favorite);
                return Ok(new { message = "Produto favoritado cadastrado com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("favorite")]
        public ActionResult Put([FromBody] FavoriteDTO favorite)
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

                _serviceFavorite.Update(favorite);
                return Ok(new { message = "Produto atualizado com sucesso" });
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpDelete("favorite")]
        public ActionResult Delete([FromBody] FavoriteDTO favorite)
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

                _serviceFavorite.Remove(favorite);
                return Ok(new { message = "Produto removido com sucesso!" });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}

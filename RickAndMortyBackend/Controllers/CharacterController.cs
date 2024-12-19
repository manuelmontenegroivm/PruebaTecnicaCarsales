using Microsoft.AspNetCore.Mvc;
using RickAndMortyBackend.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _charactereServicio;

        public CharacterController(ICharacterService charactereServicio)
        {
            _charactereServicio = charactereServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosPersonajes()
        {
            try
            {
                var resultado = await _charactereServicio.ObtenerTodosLosPersonajes();
                if (resultado.resultado)
                    return Ok(resultado.characterResponse);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerPersonajesPaginado")]
        public async Task<IActionResult> ObtenerPersonajesPaginado([FromQuery] int pagina = 1)
        {
            try
            {
                var resultado = await _charactereServicio.ObtenerPersonajesPaginado(pagina);
                if (resultado.resultado)
                    return Ok(resultado.characterPaginatedResponse);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerPersonajePorId")]
        public async Task<IActionResult> ObtenerPersonajePorId([FromQuery] int id)
        {
            try
            {
                var resultado = await _charactereServicio.ObtenerPersonajePorId(id);
                if (resultado.resultado)
                    return Ok(resultado.character);
                return NotFound(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerMultiplesPersonajesPorId")]
        public async Task<IActionResult> ObtenerMultiplesPersonajesPorId([FromQuery] int[] ids)
        {
            try
            {
                var resultado = await _charactereServicio.ObtenerMultiplesPersonajesPorId(ids);
                if (resultado.resultado)
                    return Ok(resultado.characters);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

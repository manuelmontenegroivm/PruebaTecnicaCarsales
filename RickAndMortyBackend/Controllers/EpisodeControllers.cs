using RickAndMortyBackend.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodeControler : ControllerBase
    {
        private readonly IEpisodeService _episodioServicio;

        public EpisodeControler(IEpisodeService episodioServicio)
        {
            _episodioServicio = episodioServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosEpisodios()
        {
            try
            {
                var resultado = await _episodioServicio.ObtenerTodosLosEpisodios();
                if (resultado.resultado)
                    return Ok(resultado.episodiosRespuesta);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerEpisodiosPaginado")]
        public async Task<IActionResult> ObtenerEpisodiosPaginado([FromQuery] int pagina = 1)
        {
            try
            {
                var resultado = await _episodioServicio.ObtenerEpisodiosPaginado(pagina);
                if (resultado.resultado)
                    return Ok(resultado.episodePaginatedResponse);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerEpisodioPorId")]
        public async Task<IActionResult> ObtenerEpisodioPorId([FromQuery] int id)
        {
            try
            {
                var resultado = await _episodioServicio.ObtenerEpisodioPorId(id);
                if (resultado.resultado)
                    return Ok(resultado.Episode);
                return NotFound(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerMultiplesEpisodiosPorId")]
        public async Task<IActionResult> ObtenerMultiplesEpisodiosPorId([FromQuery] int[] ids)
        {
            try
            {
                var resultado = await _episodioServicio.ObtenerMultiplesEpisodiosPorId(ids);
                if (resultado.resultado)
                    return Ok(resultado.episodes);
                return BadRequest(resultado.mensajeError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

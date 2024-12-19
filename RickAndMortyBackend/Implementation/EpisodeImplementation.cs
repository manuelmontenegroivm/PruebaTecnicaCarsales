
using RickAndMortyBackend.Interfaces;
using RickAndMortyBackend.Models;
using RickAndMortyBackend.Models.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ickAndMortyBackend.Models.Responses;

namespace RickAndMortyBackend.Implementation
{
    public class EpisodeImplementation : IEpisodeService
    {
        private readonly ILogger<EpisodeImplementation> _logger;
        private readonly IHttpClientFactory _httpClient;

        public EpisodeImplementation(ILogger<EpisodeImplementation> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<(bool resultado, Episode Episode, string mensajeError)> ObtenerEpisodioPorId(int id)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync($"api/episode/{id}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<Episode>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, EpisodePaginatedResponse episodePaginatedResponse, string mensajeError)> ObtenerEpisodiosPaginado(int pagina)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync($"api/episode/?page={pagina}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<EpisodePaginatedResponse>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, List<Episode> episodes, string mensajeError)> ObtenerMultiplesEpisodiosPorId(int[] ids)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");

                var idsConcatenados = string.Join(",", ids);

                var respuesta = await cliente.GetAsync($"api/episode/{idsConcatenados}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<List<Episode>>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, AllEpisodeResponse episodiosRespuesta, string mensajeError)> ObtenerTodosLosEpisodios()
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync("api/episode");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<AllEpisodeResponse>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}

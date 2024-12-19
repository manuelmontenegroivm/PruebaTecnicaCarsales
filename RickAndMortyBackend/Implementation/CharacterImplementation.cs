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

namespace RickAndMortyBackend.Implementation
{
    public class CharacterImplementation : ICharacterService
    {
        private readonly ILogger<CharacterImplementation> _logger;
        private readonly IHttpClientFactory _httpClient;

        public CharacterImplementation(ILogger<CharacterImplementation> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<(bool resultado, List<Character> characters, string mensajeError)> ObtenerMultiplesPersonajesPorId(int[] ids)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");

                var idsConcatenados = string.Join(",", ids);

                var respuesta = await cliente.GetAsync($"api/character/{idsConcatenados}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<List<Character>>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, Character character, string mensajeError)> ObtenerPersonajePorId(int id)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync($"api/character/{id}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<Character>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, CharacterPaginatedResponse characterPaginatedResponse, string mensajeError)> ObtenerPersonajesPaginado(int pagina)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync($"api/character/?page={pagina}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<CharacterPaginatedResponse>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, AllCharacterResponse characterResponse, string mensajeError)> ObtenerTodosLosPersonajes()
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync("api/character");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<AllCharacterResponse>(contenido, opciones);

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

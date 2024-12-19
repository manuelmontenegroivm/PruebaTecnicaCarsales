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

namespace RickAndMortyBackend.Implementaciones
{
    public class LocationImplementation : ILocationService
    {
        private readonly ILogger<LocationImplementation> _logger;
        private readonly IHttpClientFactory _httpClient;

        public LocationImplementation(ILogger<LocationImplementation> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<(bool resultado, LocationPaginatedResponse locationPaginatedResponse, string mensajeError)> ObtenerLocalizacionesPaginado(int pagina)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync($"api/location/?page={pagina}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<LocationPaginatedResponse>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, Location localizacion, string mensajeError)> ObtenerLocalizacionPorId(int id)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync($"api/location/{id}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<Location>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, List<Location> localizaciones, string mensajeError)> ObtenerMultiplesLocalizacionesPorId(int[] ids)
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");

                var idsConcatenados = string.Join(",", ids);

                var respuesta = await cliente.GetAsync($"api/location/{idsConcatenados}");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<List<Location>>(contenido, opciones);

                return (true, resultado, null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool resultado, AllLocationResponse locationResponse, string mensajeError)> ObtenerTodasLasLocalizaciones()
        {
            try
            {
                var cliente = _httpClient.CreateClient("RickAndMortyBackend");
                var respuesta = await cliente.GetAsync("api/location");
                if (!respuesta.IsSuccessStatusCode)
                    return (false, null, respuesta.ReasonPhrase);

                var contenido = await respuesta.Content.ReadAsStringAsync();
                var opciones = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<AllLocationResponse>(contenido, opciones);

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

using RickAndMortyBackend.Models;
using RickAndMortyBackend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Interfaces
{
    public interface ILocationService
    {
        Task<(bool resultado, AllLocationResponse locationResponse, string mensajeError)> ObtenerTodasLasLocalizaciones();
        Task<(bool resultado, LocationPaginatedResponse locationPaginatedResponse, string mensajeError)> ObtenerLocalizacionesPaginado(int pagina);
        Task<(bool resultado, Location localizacion, string mensajeError)> ObtenerLocalizacionPorId(int id);
        Task<(bool resultado, List<Location> localizaciones, string mensajeError)> ObtenerMultiplesLocalizacionesPorId(int[] ids);
    }
}

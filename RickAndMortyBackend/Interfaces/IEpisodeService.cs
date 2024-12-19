using ickAndMortyBackend.Models.Responses;
using RickAndMortyBackend.Models;
using RickAndMortyBackend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Interfaces
{
    public interface IEpisodeService
    {
        Task<(bool resultado, AllEpisodeResponse episodiosRespuesta, string mensajeError)> ObtenerTodosLosEpisodios();
        Task<(bool resultado, EpisodePaginatedResponse episodePaginatedResponse, string mensajeError)> ObtenerEpisodiosPaginado(int pagina);
        Task<(bool resultado, Episode Episode, string mensajeError)> ObtenerEpisodioPorId(int id);
        Task<(bool resultado, List<Episode> episodes, string mensajeError)> ObtenerMultiplesEpisodiosPorId(int[] ids);
    }
}






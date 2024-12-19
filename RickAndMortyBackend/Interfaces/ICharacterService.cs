using RickAndMortyBackend.Models;
using RickAndMortyBackend.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Interfaces
{
    public interface ICharacterService
    {
        Task<(bool resultado, AllCharacterResponse characterResponse, string mensajeError)> ObtenerTodosLosPersonajes();
        Task<(bool resultado, CharacterPaginatedResponse characterPaginatedResponse, string mensajeError)> ObtenerPersonajesPaginado(int pagina);
        Task<(bool resultado, Character character, string mensajeError)> ObtenerPersonajePorId(int id);
        Task<(bool resultado, List<Character> characters, string mensajeError)> ObtenerMultiplesPersonajesPorId(int[] ids);
    }
}

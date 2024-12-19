
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RickAndMortyBackend.Models;

namespace ickAndMortyBackend.Models.Responses
{
    public class EpisodePaginatedResponse
    {
        public Info Info { get; set; }
        public List<Episode> Results { get; set; }
    }
}

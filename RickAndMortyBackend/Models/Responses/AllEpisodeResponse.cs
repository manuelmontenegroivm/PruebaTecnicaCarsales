using RickAndMortyBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Models.Responses
{
    public class AllEpisodeResponse
    {
        public Info Info { get; set; }
        public List<Episode> Results { get; set; }
    }
}

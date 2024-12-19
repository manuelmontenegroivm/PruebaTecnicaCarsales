using RickAndMortyBackend.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Models.Responses
{
    public class AllLocationResponse
    {
        public Info Info { get; set; }
        public List<Location> Results { get; set; }
    }
}

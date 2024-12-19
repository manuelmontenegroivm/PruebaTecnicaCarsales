using RickAndMortyBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Models.Responses
    {
        public class AllCharacterResponse
        {
            public Info Info { get; set; }
            public List<Character> Results { get; set; }
        }
    }

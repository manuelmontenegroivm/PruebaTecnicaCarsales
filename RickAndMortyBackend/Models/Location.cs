using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Models
{
    public class Location : RickAndMorty
    {
        public string Dimension { get; set; }
        public List<string> Residents { get; set; }
        public override string TypeCapture => nameof(Location);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RickAndMortyBackend.Models
{
    public class Episode : RickAndMorty
    {
        public override string TypeCapture => nameof(Episode);

        public string Air_Date { get; set; }
        [JsonPropertyName("episode")]
        public string EpisodeName { get; set; }
        public List<string> Characters { get; set; }
    }
}

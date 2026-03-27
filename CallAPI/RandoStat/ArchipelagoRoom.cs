using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NoNiDev.CallAPI.RandoStat
{
    public class ArchipelagoRoom
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        [JsonPropertyName("nbJoueurs")]
        public int PlayerNumber { get; set; }
        [JsonPropertyName("nbJeux")]
        public int GameNumber { get; set; }
        [JsonPropertyName("etat")]
        public string State { get; set; } = string.Empty;
        [JsonPropertyName("checks")]
        public int CheckNumber { get; set; }
    }
}

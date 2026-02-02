using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NoNiDev.SpoilerArchipelagoParser.Options
{
    public abstract class GameOptions
    {
        [JsonPropertyName("joueur")]
        public string PlayerName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        [JsonIgnore]
        public Dictionary<string, string> Options { get; init; } = [];
    }
}

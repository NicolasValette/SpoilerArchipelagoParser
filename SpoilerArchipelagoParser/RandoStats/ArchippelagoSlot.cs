using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace NoNiDev.SpoilerArchipelagoParser.RandoStats
{
    public class ArchippelagoSlot (string name, string game, int locCount)
    {
        [JsonPropertyName("joueur")]
        public string Name { get; set; } = name;
        [JsonPropertyName("jeu")]
        public string Game { get; init; } = game;
        [JsonPropertyName("checks")]
        public int LocationCount { get; set; } = locCount;
    }
}
